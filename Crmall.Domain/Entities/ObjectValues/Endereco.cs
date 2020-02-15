namespace Crmall.Domain.Entities.ObjectValues
{
    public class Endereco
    {
        public Endereco(string cep,
                        string logradouro,
                        string numero,
                        string complemento,
                        string bairro,
                        string cidade)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
    }
}
