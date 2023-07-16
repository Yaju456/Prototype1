﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prototype1.Data;

#nullable disable

namespace Prototype1.Migrations
{
    [DbContext(typeof(ApplicationDbConetext))]
    partial class ApplicationDbConetextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prototype1.Models.ShowClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("imgurl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Show");
                });

            modelBuilder.Entity("Prototype1.Models.ShowDateClass", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<int>("Checked")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qrvalue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShowTicketID")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("ShowTicketID");

                    b.ToTable("ShowDate");
                });

            modelBuilder.Entity("Prototype1.Models.ShowTIcketsClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ShowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShowID")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalTickets")
                        .HasColumnType("int");

                    b.Property<int>("soldTickets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShowID");

                    b.ToTable("showTickets");
                });

            modelBuilder.Entity("Prototype1.Models.ShowDateClass", b =>
                {
                    b.HasOne("Prototype1.Models.ShowTIcketsClass", "showTIcketsClass")
                        .WithMany()
                        .HasForeignKey("ShowTicketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("showTIcketsClass");
                });

            modelBuilder.Entity("Prototype1.Models.ShowTIcketsClass", b =>
                {
                    b.HasOne("Prototype1.Models.ShowClass", "Show")
                        .WithMany()
                        .HasForeignKey("ShowID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });
#pragma warning restore 612, 618
        }
    }
}
