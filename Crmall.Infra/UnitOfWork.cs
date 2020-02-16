using System;
using Crmall.Domain.Contracts.Repository;

namespace Crmall.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClienteDataContext _clienteDataContext;

        public UnitOfWork(ClienteDataContext clienteDataContext)
        {
            _clienteDataContext = clienteDataContext;
        }

        public int Commit()
        {
            return _clienteDataContext.SaveChanges();
        }
    }
}
