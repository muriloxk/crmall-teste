using System;
using System.Collections.Generic;
using System.Linq;
using Crmall.Domain.Entities;
using Crmall.Domain.Entities.ObjectValues;
using Crmall.Domain.Queries;
using Xunit;

namespace Crmall.Tests.QueriesTest
{
    public class ClientesQueriesTest
    {
        private List<Cliente> _clientes;

        private Guid _idTesteFiltro;

        public ClientesQueriesTest()
        {
            _idTesteFiltro = Guid.NewGuid();

            _clientes = new List<Cliente>()
            {
                new Cliente(_idTesteFiltro,
                            "Murilo Sanches",
                            DateTime.Now,
                            ESexo.Masculino,
                               new Endereco("87055-280",
                                            "Rua Pioneiro José Raimundo de Oliveira",
                                            "128",
                                            null,
                                            "São Silvestre",
                                            "Maringá",
                                            "PR")),
                new Cliente(_idTesteFiltro,
                            "Sebastião Cobre Sanches",
                            DateTime.Now,
                            ESexo.Masculino,
                                new Endereco("87055-280",
                                            "Rua Pioneiro José Raimundo de Oliveira",
                                            "128",
                                            null,
                                            "São Silvestre",
                                            "Maringá",
                                            "PR")),

              new Cliente(_idTesteFiltro,
                          "Neusa Lourenço Cobre Sanches",
                          DateTime.Now,
                          ESexo.Masculino,
                            new Endereco("87055-280",
                                         "Rua Pioneiro José Raimundo de Oliveira",
                                         "128",
                                         null,
                                         "São Silvestre",
                                         "Maringá",
                                         "PR")),
            };
        }

        [Fact]
        public void Dado_O_Id_Do_Cliente_Deve_Retornar_O_Cliente_Com_O_Mesmo_Id()
        {
            //Act
            var cliente = _clientes.AsQueryable()
                                   .Where(ClienteQueries.BuscarPeloId(_idTesteFiltro))
                                   .FirstOrDefault();

            Assert.NotNull(cliente);
            Assert.Equal(cliente.Id, _idTesteFiltro);
        }
    }
}
