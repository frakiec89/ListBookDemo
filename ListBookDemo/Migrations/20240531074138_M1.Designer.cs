﻿// <auto-generated />
using System;
using ListBookDemo.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ListBookDemo.DB.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20240531074138_M1")]
    partial class M1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("ListBookDemo.DB.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Experience")
                        .HasColumnType("REAL");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Experience = 100.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "C# Для  чайников",
                            Price = 50.0
                        },
                        new
                        {
                            BookId = 2,
                            Experience = 1000.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "C# Для  мидлов",
                            Price = 500.0
                        },
                        new
                        {
                            BookId = 3,
                            Experience = 1000.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "C# Для  Проффи",
                            Price = 5000.0
                        });
                });

            modelBuilder.Entity("ListBookDemo.DB.BookHistory", b =>
                {
                    b.Property<int>("BookHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookHistoryId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookHistories");
                });

            modelBuilder.Entity("ListBookDemo.DB.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "TestUser"
                        });
                });

            modelBuilder.Entity("ListBookDemo.DB.BookHistory", b =>
                {
                    b.HasOne("ListBookDemo.DB.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ListBookDemo.DB.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
