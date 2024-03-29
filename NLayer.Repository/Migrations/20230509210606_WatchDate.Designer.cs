﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230509210606_WatchDate")]
    partial class WatchDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NLayer.Core.Models.CanceledWatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CanceledWatchTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CanceledWatches", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CanceledWatchTime = new DateTimeOffset(new DateTime(2023, 5, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PersonnelId = 1,
                            WatchId = 1
                        },
                        new
                        {
                            Id = 2,
                            CanceledWatchTime = new DateTimeOffset(new DateTime(2023, 5, 4, 12, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PersonnelId = 2,
                            WatchId = 2
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PersonnelSeniorityId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonnelSeniorityId");

                    b.HasIndex("WatchId");

                    b.ToTable("Personnels", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Damla Nur",
                            PersonnelSeniorityId = 1,
                            Surname = "Korkmaz",
                            Title = "Uzman",
                            WatchId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Eda Nur",
                            PersonnelSeniorityId = 2,
                            Surname = "Korkmaz",
                            Title = "Uzman",
                            WatchId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Elif",
                            PersonnelSeniorityId = 3,
                            Surname = "Korkmaz",
                            Title = "Uzman",
                            WatchId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Semih Berkay",
                            PersonnelSeniorityId = 1,
                            Surname = "Korkmaz",
                            Title = "Uzman",
                            WatchId = 1
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.PersonnelSeniority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<string>("SeniorityType")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("PersonnelSeniorities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PersonnelId = 1,
                            SeniorityType = "High"
                        },
                        new
                        {
                            Id = 2,
                            PersonnelId = 2,
                            SeniorityType = "Mid"
                        },
                        new
                        {
                            Id = 3,
                            PersonnelId = 3,
                            SeniorityType = "Junior"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4977),
                            Name = "Kalem1",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4990),
                            Name = "Kalem2",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4993),
                            Name = "Kalem3",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4996),
                            Name = "Kitap1",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4998),
                            Name = "Kitap2",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 5, 10, 0, 6, 6, 381, DateTimeKind.Local).AddTicks(4999),
                            Name = "Kitap3",
                            Price = 100m,
                            Stock = 20
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Kırmızı",
                            Height = 100,
                            ProductId = 1,
                            Width = 200
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.Watch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WatchDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("WatchEndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("WatchStartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("WeekWatch")
                        .HasColumnType("varchar");

                    b.Property<string>("WeekendWatch")
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("PersonnelId");

                    b.ToTable("Watches", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PersonnelId = 1,
                            WatchDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WatchEndTime = new DateTimeOffset(new DateTime(2023, 5, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            WatchStartTime = new DateTimeOffset(new DateTime(2023, 5, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            WeekWatch = "",
                            WeekendWatch = ""
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.Personnel", b =>
                {
                    b.HasOne("NLayer.Core.Models.PersonnelSeniority", "PersonnelSeniority")
                        .WithMany("Personnels")
                        .HasForeignKey("PersonnelSeniorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NLayer.Core.Models.Watch", "Watch")
                        .WithMany("Personnels")
                        .HasForeignKey("WatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonnelSeniority");

                    b.Navigation("Watch");
                });

            modelBuilder.Entity("NLayer.Core.Models.Product", b =>
                {
                    b.HasOne("NLayer.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NLayer.Core.Models.ProductFeature", b =>
                {
                    b.HasOne("NLayer.Core.Models.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NLayer.Core.Models.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NLayer.Core.Models.Watch", b =>
                {
                    b.HasOne("NLayer.Core.Models.CanceledWatch", "CanceledWatches")
                        .WithMany("Watches")
                        .HasForeignKey("PersonnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CanceledWatches");
                });

            modelBuilder.Entity("NLayer.Core.Models.CanceledWatch", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("NLayer.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NLayer.Core.Models.PersonnelSeniority", b =>
                {
                    b.Navigation("Personnels");
                });

            modelBuilder.Entity("NLayer.Core.Models.Product", b =>
                {
                    b.Navigation("ProductFeature");
                });

            modelBuilder.Entity("NLayer.Core.Models.Watch", b =>
                {
                    b.Navigation("Personnels");
                });
#pragma warning restore 612, 618
        }
    }
}
