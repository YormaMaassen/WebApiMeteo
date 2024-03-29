﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiMeteo.Db;

#nullable disable

namespace WebApiMeteo.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiMeteo.Entities.Meteo", b =>
                {
                    b.Property<int>("MeteoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureMax")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureMin")
                        .HasColumnType("float");

                    b.Property<int>("Temps")
                        .HasColumnType("int");

                    b.Property<int>("VilleId")
                        .HasColumnType("int");

                    b.Property<double>("VitesseDuVent")
                        .HasColumnType("float");

                    b.HasKey("MeteoId");

                    b.ToTable("Meteo", (string)null);
                });

            modelBuilder.Entity("WebApiMeteo.Entities.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Ville", (string)null);
                });

            modelBuilder.Entity("WebApiMeteo.Entities.Meteo", b =>
                {
                    b.HasOne("WebApiMeteo.Entities.Ville", "Ville")
                        .WithMany("Meteos")
                        .HasForeignKey("MeteoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Meteo_VilleId_ToTable_Ville_Id");

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("WebApiMeteo.Entities.Ville", b =>
                {
                    b.Navigation("Meteos");
                });
#pragma warning restore 612, 618
        }
    }
}
