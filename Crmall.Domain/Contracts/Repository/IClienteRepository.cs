using System;
using System.Collections.Generic;
using Crmall.Domain.Entities;

namespace Crmall.Domain.Contracts.Repository
{
    public interface IClienteRepository
    {
        void Novo(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(Guid id);
        Cliente BuscarPorId(Guid id);

        IEnumerable<Cliente> BuscarTodos();
    }
}
