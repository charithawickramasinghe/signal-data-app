﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalDataApp.Data;

namespace SignalDataApp.Data.Migrations
{
    [DbContext(typeof(SignalDataDBContext))]
    partial class SignalDataDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SignalDataApp.Data.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("SignalDataApp.Data.Entities.Signal", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Signals");
                });

            modelBuilder.Entity("SignalDataApp.Data.Entities.SignalValue", b =>
                {
                    b.Property<int>("SignalValuelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReadUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("SignalId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SignalValuelId");

                    b.HasIndex("SignalId");

                    b.ToTable("SignalValues");
                });

            modelBuilder.Entity("SignalDataApp.Data.Entities.Signal", b =>
                {
                    b.HasOne("SignalDataApp.Data.Entities.Building", "Building")
                        .WithMany("Signals")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("SignalDataApp.Data.Entities.SignalValue", b =>
                {
                    b.HasOne("SignalDataApp.Data.Entities.Signal", "Signal")
                        .WithMany("SignalValues")
                        .HasForeignKey("SignalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Signal");
                });

            modelBuilder.Entity("SignalDataApp.Data.Entities.Building", b =>
                {
                    b.Navigation("Signals");
                });

            modelBuilder.Entity("SignalDataApp.Data.Entities.Signal", b =>
                {
                    b.Navigation("SignalValues");
                });
#pragma warning restore 612, 618
        }
    }
}