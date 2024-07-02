﻿// <auto-generated />
using Labb2_Linq.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2_Linq.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240702110015_DbInit")]
    partial class DbInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb2_Linq.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("FkClassId")
                        .HasColumnType("int");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentId");

                    b.HasIndex("FkClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Labb2_Linq.Models.StudentCourse", b =>
                {
                    b.Property<int>("FkStudentId")
                        .HasColumnType("int");

                    b.Property<int>("FkCourseId")
                        .HasColumnType("int");

                    b.HasKey("FkStudentId", "FkCourseId");

                    b.HasIndex("FkCourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Labb2_Linq.Models.TeacherCourse", b =>
                {
                    b.Property<int>("FkTeacherId")
                        .HasColumnType("int");

                    b.Property<int>("FkCourseId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("FkTeacherId", "FkCourseId");

                    b.HasIndex("FkCourseId");

                    b.ToTable("TeacherCourses");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Student", b =>
                {
                    b.HasOne("Labb2_Linq.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("FkClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Labb2_Linq.Models.StudentCourse", b =>
                {
                    b.HasOne("Labb2_Linq.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("FkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_Linq.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("FkStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Labb2_Linq.Models.TeacherCourse", b =>
                {
                    b.HasOne("Labb2_Linq.Models.Course", "Course")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("FkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_Linq.Models.Teacher", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("FkTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Course", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("TeacherCourses");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Labb2_Linq.Models.Teacher", b =>
                {
                    b.Navigation("TeacherCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
