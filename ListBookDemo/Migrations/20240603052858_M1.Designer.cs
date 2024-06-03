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
    [Migration("20240603052858_M1")]
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
                            Name = "Чистый код”, Роберт Мартин",
                            Price = 500.0
                        },
                        new
                        {
                            BookId = 3,
                            Experience = 1000.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "Программист-прагматик. Путь от подмастерья к мастеру”, Эндрю Хант и Дэвид Томас",
                            Price = 5000.0
                        },
                        new
                        {
                            BookId = 7,
                            Experience = 1000.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "Алгоритмы. Построение и анализ”, Томас Х. Кормен, Чарльз И. Лейзерсон, Рональд Л. Ривест, Клиффорд Штайн",
                            Price = 5000.0
                        },
                        new
                        {
                            BookId = 4,
                            Experience = 1000.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "Рефакторинг. Улучшение существующего кода”, Мартин Фаулер",
                            Price = 5000.0
                        },
                        new
                        {
                            BookId = 5,
                            Experience = 1000.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "Искусство программирования”, Дональд Кнут",
                            Price = 5000.0
                        },
                        new
                        {
                            BookId = 6,
                            Experience = 1000.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "“Шаблоны корпоративных приложений”, Мартин Фаулер",
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

            modelBuilder.Entity("ListBookDemo.DB.Model.StatusUser", b =>
                {
                    b.Property<int>("StatusUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<double>("MinExperience")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SalaryCoefficient")
                        .HasColumnType("REAL");

                    b.HasKey("StatusUserId");

                    b.ToTable("StatusUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("StatusUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ListBookDemo.DB.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Experience")
                        .HasColumnType("REAL");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StatusUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("StatusUserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Experience = 0.0,
                            ImagePath = "/Image\\NoImage.png",
                            Name = "TestUser"
                        });
                });

            modelBuilder.Entity("ListBookDemo.DB.Model.Junior", b =>
                {
                    b.HasBaseType("ListBookDemo.DB.Model.StatusUser");

                    b.HasDiscriminator().HasValue("Junior");
                });

            modelBuilder.Entity("ListBookDemo.DB.Model.Middle", b =>
                {
                    b.HasBaseType("ListBookDemo.DB.Model.StatusUser");

                    b.HasDiscriminator().HasValue("Middle");
                });

            modelBuilder.Entity("ListBookDemo.DB.BookHistory", b =>
                {
                    b.HasOne("ListBookDemo.DB.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ListBookDemo.DB.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ListBookDemo.DB.Model.User", b =>
                {
                    b.HasOne("ListBookDemo.DB.Model.StatusUser", "Status")
                        .WithMany()
                        .HasForeignKey("StatusUserId");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
