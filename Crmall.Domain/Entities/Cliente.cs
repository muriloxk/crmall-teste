using System;
using Crmall.Domain.Entities.ObjectValues;

namespace Crmall.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ESexo Sexo { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente(string nome,
                       DateTime dataNascimento,
                       ESexo sexo,
                       Endereco endereco)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Endereco = endereco;
        }

        public Cliente(Guid id,
                       string nome,
                       DateTime dataNascimento,
                       ESexo sexo,
                       Endereco endereco) : this(nome, dataNascimento, sexo, endereco) 
        {
            Id = id;
        }
    }
}
