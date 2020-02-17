using System;
using Crmall.Domain.Contracts.Commands;
using Crmall.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace Crmall.Domain.Commands
{
    public class AtualizarClienteCommand : Notifiable, ICommand
    {
        public AtualizarClienteCommand() { }

        public AtualizarClienteCommand(
                                  Guid id,
                                  string nome,
                                  DateTime dataNascimento,
                                  ESexo sexo,
                                  string cep = null,
                                  string logradouro = null,
                                  string numero = null,
                                  string complemento = null,
                                  string bairro = null,
                                  string cidade = null,
                                  string estado = null)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public ESexo Sexo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                                 .Requires()
                                 .IsNotNull(Id, "ID", "O Id é obrigatório para atualizar o cliente")
                                 .AreNotEquals(Id, Guid.Empty, "ID", "O Id é obrigatório para atualizar o cliente")
                                 .HasMinLen(Nome, 4, "Nome", "Por favor, preencha o nome do cliente, minimo 4 caracteres.")
                                 .IsNotNull(Sexo, "Sexo", "Por favor, preencha o sexo")
                                 .IsBetween((int)Sexo, 0, 2, "Sexo", "Por favor preencha o sexo corretamente. [0 = Masculino, 1 = Feminino, 2 = Outro]")
                                 .IsBetween(DataNascimento,
                                            DateTime.Now.AddYears(-140).Date,
                                             DateTime.Now.AddDays(1).Date,
                                            "Data de nascimento",
                                            "Por favor, preencha uma data de nascimento válida. (Não permitido mais de 140 anos ou datas futuras)")
                             );
        }
    }
}
