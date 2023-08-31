using AutoMapper;
using FI.AtividadeEntrevista.BLL;
using System;
using System.Collections.Generic;
using WebAtividadeEntrevista.Models;


namespace WebAtividadeEntrevista.Services.Clientes
{
    public class ServiceCliente : IServiceCliente
    {
        private IMapper mapper;

        private IBoCliente _boCliente;
        public ServiceCliente(IBoCliente boCliente)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClienteProfile>();
            });

            mapper = configuration.CreateMapper();

            _boCliente = boCliente;
        }

        public void Alterar(ClienteModel model)
        {
            try
            {
                _boCliente.Alterar(mapper.Map<FI.AtividadeEntrevista.DML.Cliente>(model));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ClienteModel Consultar(long id)
        {
            FI.AtividadeEntrevista.DML.Cliente cliente = _boCliente.Consultar(id);
            Models.ClienteModel model = null;

            if (cliente != null)
                model = mapper.Map<ClienteModel>(cliente);
            return model;
        }

        public long Incluir(ClienteModel model)
        {
            // valida o cpf informado
            if (!_boCliente.VerificarExistencia(model.CPF))
            {
                FI.AtividadeEntrevista.DML.Cliente clienteIncluir = mapper.Map<FI.AtividadeEntrevista.DML.Cliente>(model);
                long Id = _boCliente.Incluir(clienteIncluir);
                return Id;
            }
            return 0;
        }

        public List<ClienteModel> ListarClientes(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            List<ClienteModel> lista = null;
            List<FI.AtividadeEntrevista.DML.Cliente> clientes = _boCliente.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
            if (clientes != null)
                lista = mapper.Map<List <FI.AtividadeEntrevista.DML.Cliente>, List <ClienteModel>>(clientes);

            return lista;
        }

    }
}