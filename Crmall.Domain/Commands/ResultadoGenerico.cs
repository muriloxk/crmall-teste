using Crmall.Domain.Contracts.Commands;

namespace Crmall.Domain.Commands
{
    public class ResultadoGenerico : ICommandResult
    {
        public ResultadoGenerico() {}

        public ResultadoGenerico(bool sucesso, string message, object data)
        {
            Sucesso = sucesso;
            Message = message;
            Data = data;
        }

        public bool Sucesso { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
