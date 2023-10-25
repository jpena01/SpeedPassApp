﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpeedPassApp;

#nullable disable

namespace SpeedPassApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231025142958_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpeedPassApp.Models.Order", b =>
                {
                    b.Property<string>("Order_Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Fulfilled_Status")
                        .HasColumnType("bit");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.HasKey("Order_Number");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}