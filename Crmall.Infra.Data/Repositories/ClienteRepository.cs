using System;
using System.Collections.Generic;
using System.Linq;
using Crmall.Domain.Contracts.Repository;
using Crmall.Domain.Entities;
using Crmall.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Crmall.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDataContext _context;

        public ClienteRepository(ClienteDataContext context)
        {
            _context = context;
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        public Cliente BuscarPorId(Guid id)
        {
            return _context.Clientes.Where(ClienteQueries.BuscarPeloId(id))
                                    .AsNoTracking()
                                    .SingleOrDefault();
        }

        public IEnumerable<Cliente> BuscarTodos()
        {
            return _context.Clientes.AsNoTracking();
        }

        public void Excluir(Guid id)
        {
            var cliente = BuscarPorId(id);

            if (cliente == null)
                return;

            _context.Remove(cliente);
        }

        public void Novo(Cliente cliente)
        {
            _context.Add(cliente);
        }
    }
}
