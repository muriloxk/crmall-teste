using System;
using Crmall.Domain.Commands;
using Crmall.Domain.Entities;
using Xunit;

namespace Crmall.Tests.CommandTest
{
    public class NovoClienteCommanTest
    {
        [Fact]
        public void Dado_Um_Comando_Invalido_Valid_Deve_Retornar_False()
        {
            //Arrange
            var command = new NovoClienteCommand("", DateTime.Now, ESexo.Masculino);

            //Act
            command.Validate();

            Assert.False(command.Valid);
        }

        [Fact]
        public void Dado_Um_Comando_Com_Data_Invalida_Deve_Retornar_Invalid_True()
        {
            //Arrange
            var command = new NovoClienteCommand("Murilo Sanches", DateTime.Now.AddYears(-200), ESexo.Masculino);

            //Act
            command.Validate();

            Assert.True(command.Invalid);
        }

        [Fact]
        public void Dado_Um_Comando_Com_Cep_Preenchido_Com_Formato_Invalido_Deve_Retornar_Invalid_True()
        {
            //Arrange
            var command = new NovoClienteCommand("Murilo Sanches", DateTime.Now, ESexo.Masculino, "87055-80");

            //Act
            command.Validate();


            Assert.True(command.Invalid);
        }

        [Fact]
        public void Dado_Um_Comando_Com_Sexo_Incorreto_Deve_Retornar_Valid_False()
        {
            //Arrange
            var command = new NovoClienteCommand("Murilo Sanches", DateTime.Now, (ESexo)3);

            //Act
            command.Validate();


            Assert.False(command.Valid);
        }

        [Fact]
        public void Dado_Um_Comando_Com_Cep_Preenchido_Deve_Validar_Se_Os_Demais_Dados_Do_Endereco_Estao_Preenchidos()
        {
            //Arrange
            var command = new NovoClienteCommand("Murilo Sanches", DateTime.Now, ESexo.Masculino, "87055-280");

            //Act
            command.Validate();


            Assert.True(command.Invalid);
        }

        [Fact]
        public void Dado_Um_Comando_Com_Endereco_Preenchido_Corretamente_Deve_Retornar_Valid_Deve_Retornar_True()
        {
            //Arrange
            var command = new NovoClienteCommand("Murilo Sanches",
                                                  DateTime.Now,
                                                  ESexo.Masculino,
                                                  "87055-280",
                                                  "Rua Pioneiro José Raimundo de Olveira",
                                                  "128",
                                                  null,
                                                  "São Silvestre",
                                                  "Maringá");
            //Act
            command.Validate();

            Assert.True(command.Valid);
        }
    }
}
