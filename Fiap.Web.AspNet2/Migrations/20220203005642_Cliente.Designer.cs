﻿// <auto-generated />
using System;
using Fiap.Web.AspNet2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.Web.AspNet2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220203005642_Cliente")]
    partial class Cliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Web.AspNet2.Models.CidadeModel", b =>
                {
                    b.Property<int>("CidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CidadeNome")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuantidadeHabitantes")
                        .HasColumnType("int");

                    b.HasKey("CidadeId");

                    b.ToTable("Cidade");

                    b.HasData(
                        new
                        {
                            CidadeId = 1,
                            CidadeNome = "São Paulo",
                            QuantidadeHabitantes = 11
                        });
                });

            modelBuilder.Entity("Fiap.Web.AspNet2.Models.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepresentanteId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("RepresentanteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Fiap.Web.AspNet2.Models.RepresentanteModel", b =>
                {
                    b.Property<int>("RepresentanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeRepresentante")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RepresentanteId");

                    b.ToTable("Representante");
                });

            modelBuilder.Entity("Fiap.Web.AspNet2.Models.ClienteModel", b =>
                {
                    b.HasOne("Fiap.Web.AspNet2.Models.RepresentanteModel", "RepresentanteModel")
                        .WithMany()
                        .HasForeignKey("RepresentanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RepresentanteModel");
                });
#pragma warning restore 612, 618
        }
    }
}