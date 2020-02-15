using Crmall.Domain.Contracts.Commands;

namespace Crmall.Domain.Contracts.Handler
{
    public interface IHandler<TCommand> where TCommand : ICommand
    {
        ICommandResult Executar(TCommand comando);
    }
}
