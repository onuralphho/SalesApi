﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalesProject.Context;

#nullable disable

namespace SalesProject.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    partial class SalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalesProject.Entities.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DiscountValue")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("SalesProject.Entities.CartProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("SalesProject.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SalesProject.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActiveCampaignId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("DiscountedPrice")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StockCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActiveCampaignId");

                    b.HasIndex("Sku")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SalesProject.Entities.CartProduct", b =>
                {
                    b.HasOne("SalesProject.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("SalesProject.Entities.Product", b =>
                {
                    b.HasOne("SalesProject.Entities.Campaign", "ActiveCampaign")
                        .WithMany()
                        .HasForeignKey("ActiveCampaignId");

                    b.Navigation("ActiveCampaign");
                });

            modelBuilder.Entity("SalesProject.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
