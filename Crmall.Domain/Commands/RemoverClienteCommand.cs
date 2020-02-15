using System;
using Crmall.Domain.Contracts.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Crmall.Domain.Commands
{
    public class RemoverClienteCommand : Notifiable, ICommand
    {
        public RemoverClienteCommand()
        {

        }

        public RemoverClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                                .Requires()
                                .AreNotEquals(Id, Guid.Empty, "Id", "O Id é obrigatório para remover um cliente"));
        }
    }
}
