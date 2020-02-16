using System;
using Crmall.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crmall.Infra
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
                              .HasColumnType("VARCHAR(10)");

            modelBuilder.Entity<Cliente>().Property(x => x.Endereco.Cep)
                                          .HasColumnName("Cep")
                                          .IsRequired()
                                          .HasColumnType("VARCHAR(10)");

            modelBuilder.Entity<Cliente>().Property(x => x.Endereco.Logradouro)
                                          .HasColumnName("Logradouro")
                                          .IsRequired()
                                          .HasColumnType("VARCHAR(80)");

            modelBuilder.Entity<Cliente>().Property(x => x.Endereco.Numero)
                                          .HasColumnName("Numero")
                                          .IsRequired()
                                          .HasColumnType("VARCHAR(10)");

            modelBuilder.Entity<Cliente>().Property(x => x.Endereco.Complemento)
                                          .HasColumnName("Complemento")
                                          .IsRequired()
                                          .HasColumnType("VARCHAR(150)");

            modelBuilder.Entity<Cliente>().Property(x => x.Endereco.Bairro)
                                          .HasColumnName("Complemento")
                                          .IsRequired()
                                          .HasColumnType("VARCHAR(80)");

            modelBuilder.Entity<Cliente>().Property(x => x.Endereco.Estado)
                                          .HasColumnName("Estado")
                                          .IsRequired()
                                          .HasColumnType("VARCHAR(45)");

            modelBuilder.Entity<Cliente>().Property(x => x.Endereco.Cidade)
                                          .HasColumnName("Cidade")
                                          .IsRequired()
                                          .HasColumnType("VARCHAR(45)");
        }
    }
}
