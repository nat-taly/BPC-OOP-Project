﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppDatabase.Data;

namespace WebAppDatabase.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220420114229_initialMigraton")]
    partial class initialMigraton
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("WebAppDatabase.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ItemName")
                        .IsUnique();

                    b.HasIndex("TypeID");

                    b.HasIndex("UnitID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("WebAppDatabase.Models.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ItemType");
                });

            modelBuilder.Entity("WebAppDatabase.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("WebAppDatabase.Models.Item", b =>
                {
                    b.HasOne("WebAppDatabase.Models.ItemType", "ItemType")
                        .WithMany("Items")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppDatabase.Models.Unit", "Unit")
                        .WithMany("Items")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("WebAppDatabase.Models.ItemType", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WebAppDatabase.Models.Unit", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}