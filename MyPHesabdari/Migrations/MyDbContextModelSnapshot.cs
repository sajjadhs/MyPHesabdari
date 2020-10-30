﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPHesabdari.Model;

namespace MyPHesabdari.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyPHesabdari.Model.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CostId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CostId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("MyPHesabdari.Model.CurrencyUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyUnits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "TurkLira"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Toman"
                        });
                });

            modelBuilder.Entity("MyPHesabdari.Model.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CostId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Payer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CostId");

                    b.HasIndex("CurrencyUnitId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("MyPHesabdari.Model.Cost", b =>
                {
                    b.HasOne("MyPHesabdari.Model.Cost", "ParentCost")
                        .WithMany()
                        .HasForeignKey("CostId");
                });

            modelBuilder.Entity("MyPHesabdari.Model.Expense", b =>
                {
                    b.HasOne("MyPHesabdari.Model.Cost", "Cost")
                        .WithMany()
                        .HasForeignKey("CostId");

                    b.HasOne("MyPHesabdari.Model.CurrencyUnit", "CurrencyUnit")
                        .WithMany()
                        .HasForeignKey("CurrencyUnitId");
                });
#pragma warning restore 612, 618
        }
    }
}
