﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProyectAntivirusBackend.Data;

#nullable disable

namespace ProyectAntivirusBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250701051212_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProyectAntivirusBackend.Models.AuthUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("auth_users");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OpportunityId")
                        .HasColumnType("integer")
                        .HasColumnName("opportunity_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("OpportunityId");

                    b.HasIndex("UserId");

                    b.ToTable("favorites", (string)null);
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<string>("Link")
                        .HasColumnType("text")
                        .HasColumnName("link");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("institutions", (string)null);
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("country");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.ToTable("localities", (string)null);
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Opportunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("AverageScore")
                        .HasColumnType("double precision")
                        .HasColumnName("average_score");

                    b.Property<string>("Benefits")
                        .HasColumnType("text")
                        .HasColumnName("benefits");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration_date");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("integer")
                        .HasColumnName("institution_id");

                    b.Property<int>("LocalityId")
                        .HasColumnType("integer")
                        .HasColumnName("locality_id");

                    b.Property<string>("Modality")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("modality");

                    b.Property<int>("OpportunityTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("opportunity_type_id");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("publication_date");

                    b.Property<int>("RatingId")
                        .HasColumnType("integer")
                        .HasColumnName("rating_id");

                    b.Property<string>("Requirements")
                        .HasColumnType("text")
                        .HasColumnName("requirements");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer")
                        .HasColumnName("sector_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("LocalityId");

                    b.HasIndex("OpportunityTypeId");

                    b.HasIndex("SectorId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("opportunities");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.OpportunityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("categories_id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("opportunity_types", (string)null);
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .HasColumnType("text")
                        .HasColumnName("biography");

                    b.Property<string>("Preferences")
                        .HasColumnType("text")
                        .HasColumnName("preferences");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("text")
                        .HasColumnName("profile_image");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("OpportunityId")
                        .HasColumnType("integer")
                        .HasColumnName("opportunity_id");

                    b.Property<double>("Score")
                        .HasColumnType("double precision")
                        .HasColumnName("score");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("OpportunityId");

                    b.HasIndex("UserId");

                    b.ToTable("rating", (string)null);
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OpportunityId")
                        .HasColumnType("integer")
                        .HasColumnName("opportunity_id");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("request_date");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("OpportunityId");

                    b.HasIndex("UserId");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("sectors", (string)null);
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("service_type_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("services");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("services_types");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("fullname");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registration_date");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("rol");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.AuthUser", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.User", "User")
                        .WithOne("AuthUser")
                        .HasForeignKey("ProyectAntivirusBackend.Models.AuthUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Favorite", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.Opportunity", "Opportunity")
                        .WithMany("Favorites")
                        .HasForeignKey("OpportunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectAntivirusBackend.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opportunity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Opportunity", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.Institution", "Institutions")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectAntivirusBackend.Models.Locality", "Localities")
                        .WithMany()
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProyectAntivirusBackend.Models.OpportunityType", "OpportunityTypes")
                        .WithMany("Opportunities")
                        .HasForeignKey("OpportunityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectAntivirusBackend.Models.Sector", "Sectors")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Institutions");

                    b.Navigation("Localities");

                    b.Navigation("OpportunityTypes");

                    b.Navigation("Sectors");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.OpportunityType", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.Category", "Categories")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Profile", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("ProyectAntivirusBackend.Models.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Rating", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.Opportunity", "Opportunity")
                        .WithMany("Ratings")
                        .HasForeignKey("OpportunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectAntivirusBackend.Models.User", null)
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");

                    b.Navigation("Opportunity");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Request", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.Opportunity", "Opportunity")
                        .WithMany()
                        .HasForeignKey("OpportunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectAntivirusBackend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opportunity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Service", b =>
                {
                    b.HasOne("ProyectAntivirusBackend.Models.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.Opportunity", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.OpportunityType", b =>
                {
                    b.Navigation("Opportunities");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.ServiceType", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("ProyectAntivirusBackend.Models.User", b =>
                {
                    b.Navigation("AuthUser");

                    b.Navigation("Favorites");

                    b.Navigation("Profile");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
