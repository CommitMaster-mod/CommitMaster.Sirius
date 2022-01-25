﻿// <auto-generated />
using System;
using CommitMaster.Sirius.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CommitMaster.Sirius.Api.Migrations
{
    [DbContext(typeof(SiriusAppContext))]
    [Migration("20220108022552_aluno_table")]
    partial class aluno_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CommitMaster.Sirius.Domain.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataAniversario")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("CommitMaster.Sirius.Domain.Entities.Aluno", b =>
                {
                    b.OwnsOne("CommitMaster.Sirius.Domain.Entities.ValueObject.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("AlunoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("varchar(20)")
                                .HasColumnName("cpf");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Alunos");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });

                    b.OwnsOne("CommitMaster.Sirius.Domain.Entities.ValueObject.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("AlunoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("varchar(20)")
                                .HasColumnName("numero_telefone");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Alunos");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });

                    b.Navigation("Cpf");

                    b.Navigation("Telefone");
                });
#pragma warning restore 612, 618
        }
    }
}