﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftDeleteSample.Data;

namespace SoftDeleteSample.Migrations
{
    [DbContext(typeof(SoftDeleteDbContext))]
    [Migration("20201227221219_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SoftDeleteSample.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Price = 10m,
                            Title = "Title 1"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Price = 11m,
                            Title = "Title 2"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Price = 12m,
                            Title = "Title 3"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Price = 13m,
                            Title = "Title 4"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Price = 14m,
                            Title = "Title 5"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Price = 15m,
                            Title = "Title 6"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Price = 16m,
                            Title = "Title 7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
