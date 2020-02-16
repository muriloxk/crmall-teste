using Crmall.Domain.Entities.ObjectValues;
using Crmall.Infra.ViaCep.Entities;
using RestSharp;
using System;

namespace Crmall.Infra.ViaCep
{
    public class BuscadorDeCep
    {
        private readonly IRestClient _client;
        private readonly IRestRequest _request;

        public BuscadorDeCep(IRestRequest request, IRestClient client)
        {
            _request = request;
            _client = client;
        }

        public Endereco BuscarCep(string cep)
        {
            _client.BaseUrl = new Uri("https://viacep.com.br/ws/");
            _request.Resource = $"{cep}/json/";
       
            IRestResponse<ResultadoCep> response =  _client.Get<ResultadoCep>(_request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            var resultadoCep = response.Data;
            var endereco = new Endereco(resultadoCep.cep,
                                        resultadoCep.logradouro,
                                        string.Empty,
                                        resultadoCep.complemento,
                                        resultadoCep.bairro,
                                        resultadoCep.localidade,
                                        resultadoCep.uf);
            return endereco;
        }
    }
}
