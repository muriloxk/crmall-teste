
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
        private Mock<IClienteRepository> _mockRepositorio = new Mock<IClienteRepository>();
        private Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();

        [Fact]
        public void Dado_Um_NovoClienteCommand_Invalido_Deve_Retornar_Sucesso_False()
        {
            //Arrange
            var novoClienteComandoClienteInvalido = new NovoClienteCommand("", DateTime.Now.AddYears(-200), ESexo.Feminino);
            var clienteHandler = new ClienteHandler(_mockRepositorio.Object, _mockUnitOfWork.Object);

            //Act
            var resultado  = (ResultadoGenerico) clienteHandler.Executar(novoClienteComandoClienteInvalido);

            Assert.False(resultado.Sucesso);
        }

        [Fact]
        public void Dado_Um_NovoClienteCommand_Valido_Deve_Retornar_Sucesso_True()
        {
            //Arrange
            var novoClienteComandoClienteValido = new NovoClienteCommand("Murilo Sanches", DateTime.Now, ESexo.Feminino);
            var clienteHandler = new ClienteHandler(_mockRepositorio.Object, _mockUnitOfWork.Object);

            //Act
            var resultado = (ResultadoGenerico)clienteHandler.Executar(novoClienteComandoClienteValido);

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public void Dado_Um_AtualizarClienteCommand_Invalido_Deve_Retornar_Sucesso_False()
        {
            //Arrange
            var atualizarClienteCommandInvalido = new AtualizarClienteCommand(Guid.Empty, "Murilo Sanches", DateTime.Now, ESexo.Feminino);
            _mockRepositorio.Setup(x => x.BuscarPorId(It.IsAny<Guid>())).Returns(It.IsAny<Cliente>());
            var clienteHandler = new ClienteHandler(_mockRepositorio.Object, _mockUnitOfWork.Object);

            //Act
            var resultado = (ResultadoGenerico)clienteHandler.Executar(atualizarClienteCommandInvalido);

            Assert.False(resultado.Sucesso);
        }

        [Fact]
        public void Dado_Um_AtualizarClienteCommmand_Valido_Deve_Retornar_Sucesso_True()
        {
            //Arrange
            var atualizarClienteCommandValido = new AtualizarClienteCommand(Guid.NewGuid(), "Murilo Sanches", DateTime.Now, ESexo.Feminino);
            _mockRepositorio.Setup(x => x.BuscarPorId(It.IsAny<Guid>())).Returns(new Cliente(Guid.NewGuid(), "Murilo Sanches", DateTime.Now, ESexo.Masculino, null));
            var clienteHandler = new ClienteHandler(_mockRepositorio.Object, _mockUnitOfWork.Object);

            //Act
            var resultado = (ResultadoGenerico)clienteHandler.Executar(atualizarClienteCommandValido);

            Assert.True(resultado.Sucesso);
        }

        [Fact]
        public void Dado_Um_AtualizarClienteCommand_Valido_Mas_Com_Um_Id_Nao_Encontrado_No_Banco_Deve_Retornar_Sucesso_False()
        {
            //Arrange
            var atualizarClienteCommandValido = new AtualizarClienteCommand(Guid.NewGuid(), "Murilo Sanches", DateTime.Now, ESexo.Feminino);
            _mockRepositorio.Setup(x => x.BuscarPorId(It.IsAny<Guid>())).Returns<Cliente>(null);
            var clienteHandler = new ClienteHandler(_mockRepositorio.Object, _mockUnitOfWork.Object);

            //Act
            var resultado = (ResultadoGenerico)clienteHandler.Executar(atualizarClienteCommandValido);

            Assert.False(resultado.Sucesso);
        }

        [Fact]
        public void Dado_Um_RemoverClienteCommand_Invalido_Deve_Retornar_Sucesso_False()
        {
            //Arrange
            var removerClienteCommandInvalido = new RemoverClienteCommand(Guid.Empty);
            var clienteHandler = new ClienteHandler(_mockRepositorio.Object, _mockUnitOfWork.Object);

            //Act
            var resultado = (ResultadoGenerico)clienteHandler.Executar(removerClienteCommandInvalido);

            Assert.False(resultado.Sucesso);
        }

        [Fact]
        public void Dado_Um_RemoverClienteCommmand_Valido_Deve_Retornar_Sucesso_True()
        {
            //Arrange
            var removerClienteCommandValido = new RemoverClienteCommand(Guid.NewGuid());
            var clienteHandler = new ClienteHandler(_mockRepositorio.Object, _mockUnitOfWork.Object);

            //Act
            var resultado = (ResultadoGenerico)clienteHandler.Executar(removerClienteCommandValido);

            Assert.True(resultado.Sucesso);
        }
    }
}
