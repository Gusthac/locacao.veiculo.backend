﻿// <auto-generated />
using System;
using LocacaoVeiculo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocacaoVeiculo.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220918210205_AcertaBD2")]
    partial class AcertaBD2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("LocacaoVeiculo.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Aniversario")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LocacaoVeiculo.Domain.Entities.Operador", b =>
                {
                    b.Property<string>("Matricula")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Matricula");

                    b.HasIndex("Matricula");

                    b.ToTable("Operadores");
                });

            modelBuilder.Entity("LocacaoVeiculo.Domain.Entities.Usuario", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserName");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LocacaoVeiculo.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("LocacaoVeiculo.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Cliente")
                        .HasForeignKey("LocacaoVeiculo.Domain.Entities.Cliente", "CPF")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LocacaoVeiculo.Domain.Entities.Operador", b =>
                {
                    b.HasOne("LocacaoVeiculo.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Operador")
                        .HasForeignKey("LocacaoVeiculo.Domain.Entities.Operador", "Matricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LocacaoVeiculo.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Cliente");

                    b.Navigation("Operador");
                });
#pragma warning restore 612, 618
        }
    }
}
