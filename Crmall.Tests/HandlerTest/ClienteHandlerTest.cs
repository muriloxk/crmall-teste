
using System;
using Crmall.Domain.Commands;
using Crmall.Domain.Contracts.Handler;
using Crmall.Domain.Contracts.Repository;
using Crmall.Domain.Entities;
using Moq;
using Xunit;

namespace Crmall.Tests.HandlerTest
{
    public class ClienteHandlerTest
    {
        [Fact]
        public void Dado_Um_NovoClienteCommand_Invalido_Deve_Retornar_Sucesso_False()
        {
            //Arrange
            var mockRepositorio = new Mock<IClienteRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var novoComandoClienteInvalido = new NovoClienteCommand("", DateTime.Now.AddYears(-200), ESexo.Feminino);
            var clienteHandler = new ClienteHandler(mockRepositorio.Object, mockUnitOfWork.Object);

            //Act
            var resultado  = (ResultadoGenerico) clienteHandler.Executar(novoComandoClienteInvalido);


            Assert.False(resultado.Sucesso);
        }

        [Fact]
        public void Dado_Um_NovoClienteCommand_Valido_Deve_Retornar_Sucesso_True()
        {
            Assert.False(true);
        }

        [Fact]
        public void Dado_Um_AtualizarClienteCommand_Invalido_Deve_Retornar_Sucesso_False()
        {
            Assert.False(true);
        }

        [Fact]
        public void Dado_Um_AtualizarClienteCommmand_Valido_Deve_Retornar_Sucesso_True()
        {
            Assert.False(true);
        }

        [Fact]
        public void Dado_Um_RemoverClienteCommand_Invalido_Deve_Retornar_Sucesso_False()
        {
            Assert.False(true);
        }

        [Fact]
        public void Dado_Um_RemoverClienteCommmand_Valido_Deve_Retornar_Sucesso_True()
        {
            Assert.False(true);
        }
    }
}
