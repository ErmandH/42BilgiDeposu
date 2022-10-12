﻿// <auto-generated />
using System;
using Ecole42Entity.MainContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecole42Entity.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Admin", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Answer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("Answer", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.AnswerQuestion", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnswerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("QuestionID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AnswerID");

                    b.HasIndex("QuestionID");

                    b.ToTable("AnswerQuestion", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Article", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdminID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("Article", "dbo");
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Function", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Project", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
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
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

            modelBuilder.Entity("Ecole42Entity.Entity.Question", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeletionStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("Question", "dbo");
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
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UsefulLink", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.User", b =>
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

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("intraID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Answer", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecole42Entity.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.AnswerQuestion", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Answer", "Answer")
                        .WithMany("AnswerQuestions")
                        .HasForeignKey("AnswerID");

                    b.HasOne("Ecole42Entity.Entity.Question", "Question")
                        .WithMany("AnswerQuestions")
                        .HasForeignKey("QuestionID");

                    b.Navigation("Answer");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Article", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Admin", "Admin")
                        .WithMany("Articles")
                        .HasForeignKey("AdminID");

                    b.HasOne("Ecole42Entity.Entity.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserID");

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Project", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Category", "Category")
                        .WithMany("Projects")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.ProjectFunction", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Function", "Function")
                        .WithMany("ProjectFunctions")
                        .HasForeignKey("FunctionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecole42Entity.Entity.Project", "Project")
                        .WithMany("ProjectFunctions")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.ProjectUsefulLink", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Project", "Project")
                        .WithMany("ProjectUsefulLinks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecole42Entity.Entity.UsefulLink", "UsefulLink")
                        .WithMany("ProjectUsefulLinks")
                        .HasForeignKey("UsefulLinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("UsefulLink");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Question", b =>
                {
                    b.HasOne("Ecole42Entity.Entity.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecole42Entity.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Admin", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Answer", b =>
                {
                    b.Navigation("AnswerQuestions");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Category", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Function", b =>
                {
                    b.Navigation("ProjectFunctions");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Project", b =>
                {
                    b.Navigation("ProjectFunctions");

                    b.Navigation("ProjectUsefulLinks");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.Question", b =>
                {
                    b.Navigation("AnswerQuestions");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.UsefulLink", b =>
                {
                    b.Navigation("ProjectUsefulLinks");
                });

            modelBuilder.Entity("Ecole42Entity.Entity.User", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}