using System;
using Crmall.Domain.Commands;
using Xunit;

namespace Crmall.Tests.CommandTest
{
    public class RemoverClienteCommandTest
    {
        [Fact]
        public void Dado_Um_Comando_Com_ID_Vazio_Invalido_Valid_Deve_Retornar_False()
        {
            //Arrange
            var command = new RemoverClienteCommand(Guid.Empty);

            //Act
            command.Validate();

            Assert.False(command.Valid);
        }
    }
}
