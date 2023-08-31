
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Services.Clientes
{
    public interface IServiceBeneficiario
    {
        List<BeneficiarioModel> ListarBeneficiarios(long Id);
        long IncluirBeneficiario(BeneficiarioModel model);
        void ExcluirBeneficiario(long Id);
    }
}