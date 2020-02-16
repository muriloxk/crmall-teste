using System;
using Crmall.Domain.Commands;
using Crmall.Domain.Contracts.Commands;
using Crmall.Domain.Contracts.Repository;
using Crmall.Domain.Entities;
using Crmall.Domain.Entities.ObjectValues;

namespace Crmall.Domain.Contracts.Handler
{
    public class ClienteHandler : IHandler<NovoClienteCommand>,
                                  IHandler<AtualizarClienteCommand>,
                                  IHandler<RemoverClienteCommand>
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteHandler(IClienteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public ICommandResult Executar(NovoClienteCommand comando)
        {
            comando.Validate();
            if (comando.Invalid)
                return new ResultadoGenerico(false, "Ops, houve um erro no cadastro do cliente.", comando.Notifications);

            Cliente cliente = ConverterNovoClienteCommandParaCliente(comando);

            _repository.Novo(cliente);
            _unitOfWork.Commit();

            return new ResultadoGenerico(true, "Cliente salvo com sucesso", cliente);
        }

        public ICommandResult Executar(AtualizarClienteCommand comando)
        {
            comando.Validate();
            if (comando.Invalid)
                return new ResultadoGenerico(false, "Ops, houve um erro para atualizar o cadastro do cliente.", comando.Notifications);

            if (!ValidarSeClienteJaEstaCadastradoNoBanco(comando.Id))
                return new ResultadoGenerico(false, "Esse cliente não está cadastrado para ser atualizado", null);

            var cliente = ConverterAtualizarClienteCommandParaCliente(comando);

            _repository.Atualizar(cliente);
            _unitOfWork.Commit();

            return new ResultadoGenerico(true, "Cliente atualizado com sucesso", cliente);
        }

        public ICommandResult Executar(RemoverClienteCommand comando)
        {
            comando.Validate();
            if(comando.Invalid)
                return new ResultadoGenerico(false, "Ops, houve um erro para excluir o cadastro do cliente.", comando.Notifications);

            _repository.Excluir(comando.Id);
            _unitOfWork.Commit();

            return new ResultadoGenerico(true, "Cliente excluido com sucesso", comando.Id);
        }

        private bool ValidarSeClienteJaEstaCadastradoNoBanco(Guid id)
        {
            return _repository.BuscarPorId(id) != null;
        }

        private Cliente ConverterAtualizarClienteCommandParaCliente(AtualizarClienteCommand comando)
        {
            return new Cliente(comando.Id,
                               comando.Nome,
                               comando.DataNascimento,
                               comando.Sexo,
                               new Endereco(comando.Cep,
                                            comando.Logradouro,
                                            comando.Numero,
                                            comando.Complemento,
                                            comando.Bairro,
                                            comando.Cidade,
                                            comando.Estado));
        }

        private  Cliente ConverterNovoClienteCommandParaCliente(NovoClienteCommand comando)
        {
            return new Cliente(comando.Nome,
                               comando.DataNascimento,
                               comando.Sexo,
                               new Endereco(comando.Cep,
                                            comando.Logradouro,
                                            comando.Numero,
                                            comando.Complemento,
                                            comando.Bairro,
                                            comando.Cidade,
                                            comando.Estado));
        }
    }
}
