using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectAntivirusBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "institutions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "localities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sectors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sectors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "services_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    rol = table.Column<string>(type: "text", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "opportunity_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    categories_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunity_types", x => x.id);
                    table.ForeignKey(
                        name: "FK_opportunity_types_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    service_type_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id);
                    table.ForeignKey(
                        name: "FK_services_services_types_service_type_id",
                        column: x => x.service_type_id,
                        principalTable: "services_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auth_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_auth_users_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    preferences = table.Column<string>(type: "text", nullable: true),
                    biography = table.Column<string>(type: "text", nullable: true),
                    profile_image = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_profiles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "opportunities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    opportunity_type_id = table.Column<int>(type: "integer", nullable: false),
                    sector_id = table.Column<int>(type: "integer", nullable: false),
                    locality_id = table.Column<int>(type: "integer", nullable: false),
                    requirements = table.Column<string>(type: "text", nullable: true),
                    benefits = table.Column<string>(type: "text", nullable: true),
                    modality = table.Column<string>(type: "text", nullable: false),
                    publication_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    institution_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    rating_id = table.Column<int>(type: "integer", nullable: false),
                    average_score = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opportunities", x => x.id);
                    table.ForeignKey(
                        name: "FK_opportunities_institutions_institution_id",
                        column: x => x.institution_id,
                        principalTable: "institutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunities_localities_locality_id",
                        column: x => x.locality_id,
                        principalTable: "localities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_opportunities_opportunity_types_opportunity_type_id",
                        column: x => x.opportunity_type_id,
                        principalTable: "opportunity_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_opportunities_sectors_sector_id",
                        column: x => x.sector_id,
                        principalTable: "sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    opportunity_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_favorites_opportunities_opportunity_id",
                        column: x => x.opportunity_id,
                        principalTable: "opportunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorites_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    opportunity_id = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<double>(type: "double precision", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_rating_opportunities_opportunity_id",
                        column: x => x.opportunity_id,
                        principalTable: "opportunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rating_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    opportunity_id = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    request_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_requests_opportunities_opportunity_id",
                        column: x => x.opportunity_id,
                        principalTable: "opportunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_auth_users_user_id",
                table: "auth_users",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_favorites_opportunity_id",
                table: "favorites",
                column: "opportunity_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_user_id",
                table: "favorites",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunities_institution_id",
                table: "opportunities",
                column: "institution_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunities_locality_id",
                table: "opportunities",
                column: "locality_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunities_opportunity_type_id",
                table: "opportunities",
                column: "opportunity_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunities_sector_id",
                table: "opportunities",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "IX_opportunities_title",
                table: "opportunities",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_opportunity_types_categories_id",
                table: "opportunity_types",
                column: "categories_id");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_user_id",
                table: "profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rating_opportunity_id",
                table: "rating",
                column: "opportunity_id");

            migrationBuilder.CreateIndex(
                name: "IX_rating_user_id",
                table: "rating",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requests_opportunity_id",
                table: "requests",
                column: "opportunity_id");

            migrationBuilder.CreateIndex(
                name: "IX_requests_user_id",
                table: "requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_services_service_type_id",
                table: "services",
                column: "service_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auth_users");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "opportunities");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "services_types");

            migrationBuilder.DropTable(
                name: "institutions");

            migrationBuilder.DropTable(
                name: "localities");

            migrationBuilder.DropTable(
                name: "opportunity_types");

            migrationBuilder.DropTable(
                name: "sectors");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
