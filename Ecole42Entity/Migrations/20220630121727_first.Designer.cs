﻿// <auto-generated />
using System;
using Ecole42Entity.MainContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecole42Entity.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220630121727_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecole42Entity.Entity.Admin", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Admin", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Function", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Function", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Project", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CateogryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Project", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.ProjectFunction", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<Guid>("FunctionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("FunctionID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectFunction", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.ProjectUsefulLink", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsefulLinkID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UsefulLinkID");

                    b.ToTable("ProjectUsefulLink", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.UsefulLink", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UsefulLink", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Project", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.ProjectFunction", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecole42Entity.Entity.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.ProjectUsefulLink", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecole42Entity.Entity.UsefulLink", "UsefulLink")
                        .WithMany()
                        .HasForeignKey("UsefulLinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("UsefulLink");
                });
#pragma warning restore 612, 618
        }
    }
}
