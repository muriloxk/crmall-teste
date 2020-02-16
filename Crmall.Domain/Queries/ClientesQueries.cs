using System;
using System.Linq.Expressions;
using Crmall.Domain.Entities;

namespace Crmall.Domain.Queries
{
    public static class ClienteQueries
    {
        public static Expression<Func<Cliente, bool>> BuscarPeloId(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
