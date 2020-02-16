using System;
using Crmall.Domain.Entities.ObjectValues;
using Crmall.Infra.ViaCep;
using Crmall.Infra.ViaCep.Entities;
using Moq;
using RestSharp;
using Xunit;

namespace Crmall.Tests.ViaCep
{
    public class BuscadorDeCepTest
    {
        [Fact]
        public void Dada_Uma_Resposta_Com_Status_200Ok_Deve_Retornar_Um_Endereco_ObjectValue()
        {
            //Arrange
            var mockClient = new Mock<IRestClient>();
            var mockRequest = new Mock<IRestRequest>();

            var resultadoCepTeste = new ResultadoCep()
            {
                cep = "87055-280",
                logradouro = "Rua Pioneiro José Raimundo de Oliveira",
                complemento = null,
                localidade = "Maringá",
                uf = "PR",
                bairro = "São Silvestre",
            };

            var response = new Mock<IRestResponse<ResultadoCep>>()
                    .SetupProperty(x => x.StatusCode, System.Net.HttpStatusCode.OK)
                    .SetupProperty(x => x.Data, resultadoCepTeste)
                    .Object;

            mockClient.Setup(x => x.Execute<ResultadoCep>(It.IsAny<IRestRequest>(), Method.GET))
                                   .Returns(response);

            var buscadorDeCep = new BuscadorDeCep(mockRequest.Object, mockClient.Object);

            //Act
            var resultado = buscadorDeCep.BuscarCep("87055-280");

            Assert.NotNull(resultado);
            Assert.IsType<Endereco>(resultado);
            Assert.Equal(resultado.Cidade, resultadoCepTeste.localidade);
        }


        [Fact]
        public void Dada_Um_Resposta_Da_Api_Diferente_De_Ok_Deve_Retornar_Null()
        {
            //Arrange
            var mockClient = new Mock<IRestClient>();
            var mockRequest = new Mock<IRestRequest>();

            var response = new Mock<IRestResponse<ResultadoCep>>()
                                .SetupProperty(x => x.StatusCode, System.Net.HttpStatusCode.BadRequest)
                                .Object;

            mockClient.Setup(x => x.Execute<ResultadoCep>(It.IsAny<IRestRequest>(), Method.GET))
                       .Returns(response);

            var buscadorDeCep = new BuscadorDeCep(mockRequest.Object, mockClient.Object);

            //Act
            var resultado = buscadorDeCep.BuscarCep("87055-280");

            Assert.Null(resultado);
        }
    }
}
