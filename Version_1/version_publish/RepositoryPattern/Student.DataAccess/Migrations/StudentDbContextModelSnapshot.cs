﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student.DataAccess.Concrete.MsSQL;

namespace Student.DataAccess.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Student.Entity.Student.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Adress2")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostCode")
                        .HasMaxLength(10)
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Student.Entity.Student.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Student.Entity.Student.Guardian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("TEXT");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuardianTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("GuardianTypeId");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("Student.Entity.Student.GuardianType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GuardianTypes");
                });

            modelBuilder.Entity("Student.Entity.Student.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student.Entity.Student.Address", b =>
                {
                    b.HasOne("Student.Entity.Student.Guardian", "Guardian")
                        .WithOne("Address")
                        .HasForeignKey("Student.Entity.Student.Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guardian");
                });

            modelBuilder.Entity("Student.Entity.Student.Guardian", b =>
                {
                    b.HasOne("Student.Entity.Student.Family", "Family")
                        .WithMany("Guardians")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student.Entity.Student.GuardianType", "GuardianType")
                        .WithMany("Guardians")
                        .HasForeignKey("GuardianTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("GuardianType");
                });

            modelBuilder.Entity("Student.Entity.Student.Student", b =>
                {
                    b.HasOne("Student.Entity.Student.Family", "Family")
                        .WithMany("Students")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Student.Entity.Student.Family", b =>
                {
                    b.Navigation("Guardians");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Student.Entity.Student.Guardian", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Student.Entity.Student.GuardianType", b =>
                {
                    b.Navigation("Guardians");
                });
#pragma warning restore 612, 618
        }
    }
}
