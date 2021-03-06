﻿using Crmall.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crmall.Infra.Data
{
    public static class ClienteBuilder
    {
        public static void BuilderCliente(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");

            modelBuilder.Entity<Cliente>().Property(x => x.Id)
                                          .IsRequired()
                                          .HasColumnType("CHAR(36)");

            modelBuilder.Entity<Cliente>().Property(x => x.Nome)
                                          .IsRequired()
                                          .HasMaxLength(150)
                                          .HasColumnType("VARCHAR(150)");

            modelBuilder.Entity<Cliente>().Property(x => x.DataNascimento)
                                          .IsRequired()
                                          .HasColumnType("DATETIME");

            modelBuilder.Entity<Cliente>().Property(x => x.Sexo)
                              .IsRequired()
                              .HasColumnType("VARCHAR(45)");

            //modelBuilder.Entity<Cliente>().Property(x => x.Cep)
            //                              .HasColumnName("Cep")
            //                              .HasColumnType("VARCHAR(10)");


            //modelBuilder.Entity<Cliente>().Property(x => x.Logradouro)
            //                    .HasColumnName("Logradouro")
            //                    .HasColumnType("VARCHAR(80)");

            //modelBuilder.Entity<Cliente>().Property(x => x.Numero)
            //                         .HasColumnName("Numero")
            //                         .HasColumnType("VARCHAR(10)");

            //modelBuilder.Entity<Cliente>().Property(x => x.Complemento)
            //                  .HasColumnName("Complemento")
            //                  .HasColumnType("VARCHAR(150)");


            //modelBuilder.Entity<Cliente>().Property(x => x.Bairro)
            //                .HasColumnName("Bairro")
            //                .IsRequired()
            //                .HasColumnType("VARCHAR(80)");


            //modelBuilder.Entity<Cliente>().Property(x => x.Estado)
            //               .HasColumnName("Estado")
            //               .HasColumnType("VARCHAR(45)");

            //modelBuilder.Entity<Cliente>().Property(x => x.Cidade)
            //              .HasColumnName("Cidade")
            //              .HasColumnType("VARCHAR(45)");



            modelBuilder.Entity<Cliente>().OwnsOne(x => x.Endereco)
                                          .Property(x => x.Cep)
                                          .HasColumnName("Cep")
                                          .HasColumnType("VARCHAR(10)");

            modelBuilder.Entity<Cliente>().OwnsOne(x => x.Endereco)
                                          .Property(x => x.Logradouro)
                                          .HasColumnName("Logradouro")
                                          .HasColumnType("VARCHAR(80)");

            modelBuilder.Entity<Cliente>().OwnsOne(x => x.Endereco)
                                          .Property(x => x.Numero)
                                          .HasColumnName("Numero")
                                          .HasColumnType("VARCHAR(10)");

            modelBuilder.Entity<Cliente>().OwnsOne(x => x.Endereco)
                                          .Property(x => x.Complemento)
                                          .HasColumnName("Complemento")
                                          .HasColumnType("VARCHAR(150)");

            modelBuilder.Entity<Cliente>().OwnsOne(x => x.Endereco)
                                          .Property(x => x.Bairro)
                                          .HasColumnName("Bairro")
                                          .HasColumnType("VARCHAR(80)");

            modelBuilder.Entity<Cliente>().OwnsOne(x => x.Endereco)
                                          .Property(x => x.Estado)
                                          .HasColumnName("Estado")
                                          .HasColumnType("VARCHAR(45)");

            modelBuilder.Entity<Cliente>().OwnsOne(x => x.Endereco)
                                          .Property(x => x.Cidade)
                                          .HasColumnName("Cidade")
                                          .HasColumnType("VARCHAR(45)");
        }
    }
}
