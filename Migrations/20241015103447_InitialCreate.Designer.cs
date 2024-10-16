﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HitBallWebServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241015103447_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HitBallWebServer.Models.Score", b =>
                {
                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("tryCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("user_score")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("user_id");

                    b.ToTable("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}