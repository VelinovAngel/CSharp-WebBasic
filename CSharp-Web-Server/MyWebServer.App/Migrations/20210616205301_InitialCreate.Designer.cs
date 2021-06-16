﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebServer.App.Data;

namespace MyWebServer.App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210616205301_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebServer.App.Data.Models.Commit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("RepositoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("MyWebServer.App.Data.Models.Repository", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("MyWebServer.App.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyWebServer.App.Data.Models.Commit", b =>
                {
                    b.HasOne("MyWebServer.App.Data.Models.User", "Creator")
                        .WithMany("Commits")
                        .HasForeignKey("CreatorId");

                    b.HasOne("MyWebServer.App.Data.Models.Repository", "Repository")
                        .WithMany("Commits")
                        .HasForeignKey("RepositoryId");

                    b.Navigation("Creator");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("MyWebServer.App.Data.Models.Repository", b =>
                {
                    b.HasOne("MyWebServer.App.Data.Models.User", "Owner")
                        .WithMany("Repositories")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MyWebServer.App.Data.Models.Repository", b =>
                {
                    b.Navigation("Commits");
                });

            modelBuilder.Entity("MyWebServer.App.Data.Models.User", b =>
                {
                    b.Navigation("Commits");

                    b.Navigation("Repositories");
                });
#pragma warning restore 612, 618
        }
    }
}
