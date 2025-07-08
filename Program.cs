using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProyectAntivirusBackend.Data;
using ProyectAntivirusBackend.Repositories;
using ProyectAntivirusBackend.Services;
using ProyectAntivirusBackend.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Conexión detectada:");
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection") ?? "No se encontró la cadena de conexión.");
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "https://app-antivirus.vercel.app"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var jwtSettings = builder.Configuration.GetSection("Jwt");
var keyValue = jwtSettings["Key"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

if (string.IsNullOrEmpty(keyValue))
    throw new InvalidOperationException("JWT Key no está configurada.");

var key = Encoding.UTF8.GetBytes(keyValue);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("authToken"))
            {
                var token = context.Request.Cookies["authToken"];
                context.Token = token;
            }
            return Task.CompletedTask;
        }
    };

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Antivirus", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en este formato: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions =>
        {
            npgsqlOptions.CommandTimeout(240);
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorCodesToAdd: null
            );
        }));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IOpportunityTypeRepository, OpportunityTypeRepository>();
builder.Services.AddScoped<OpportunityTypeService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IInstitutionRepository, InstitutionRepository>();
builder.Services.AddScoped<IInstitutionService, InstitutionService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.Urls.Add("http://localhost:5055");

app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => Results.Ok("API de Antivirus en funcionamiento"));

if (Environment.GetEnvironmentVariable("RUN_MIGRATIONS") == "true")
{
    try
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        Console.WriteLine("Migraciones aplicadas correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error aplicando migraciones:");
        Console.WriteLine(ex);
    }
}

app.MapGet("/ping", () => Results.Ok("pong")).AllowAnonymous();

app.MapGet("/test-db", async (ApplicationDbContext db) =>
{
    try
    {
        var result = await db.Institutions.FirstOrDefaultAsync();
        return result != null ? Results.Ok(result) : Results.Ok("Conexión OK, pero sin instituciones.");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error de conexión: {ex.Message}");
    }
});

app.Run();