using Crmall.Infra.ViaCep.Entities;

using RestSharp;


// SOLID
// CLEAN CODE
// TESTS

namespace Crmall.Infra.ViaCep
{
    public class Class1
    {
        private readonly IRestClient _client;
        private readonly IRestRequest _request;

        public Class1(IRestRequest request, IRestClient client)
        {
            _request = request;
            _client = client;
        }

        public ResultadoCep BuscarCep(string cep)
        {
            var resultadoCep = _client.Get<ResultadoCep>(_request)?.Data;

            return resultadoCep;
        }
    }
}
