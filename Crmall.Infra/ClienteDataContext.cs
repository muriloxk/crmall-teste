using System;
using Crmall.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crmall.Infra
{
    public class ClienteDataContext : DbContext
    {
        public ClienteDataContext(DbContextOptions<ClienteDataContext> optionsBuilder)
            : base(optionsBuilder) { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ClienteBuilder.BuilderCliente(modelBuilder);
        }
    }
}
