using AutoMapper;
using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAtividadeEntrevista.Models;
using WebAtividadeEntrevista.Services.Clientes;

namespace WebAtividadeEntrevista.Services.Clientes
{
    public class ServiceBeneficiario : IServiceBeneficiario
    {
        private IBoBeneficiario _boBeneficiario;
        private IMapper mapper;

        public ServiceBeneficiario(IBoBeneficiario boBeneficiario)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BeneficiarioProfile>();
            });
            mapper = configuration.CreateMapper();

            _boBeneficiario = boBeneficiario;
        }

        public void ExcluirBeneficiario(long Id)
        {
            _boBeneficiario.Excluir(Id);
        }

        public long IncluirBeneficiario(BeneficiarioModel model)
        {
            // valida o cpf informado
            if (!_boBeneficiario.VerificarExistencia(model.Id, model.CPF))
            {
                Beneficiario beneficiario = mapper.Map<Beneficiario>(model);
                long Id = _boBeneficiario.Incluir(beneficiario);
                return Id;
            }
            return 0;
        }

        public List<BeneficiarioModel> ListarBeneficiarios(long Id)
        {
            List<BeneficiarioModel> lista = null;
            List<Beneficiario> beneficiarios = _boBeneficiario.Listar(Id);
            if (beneficiarios != null)
                lista = mapper.Map<List<Beneficiario>, List<BeneficiarioModel>>(beneficiarios);

            return lista;
        }
    }
}