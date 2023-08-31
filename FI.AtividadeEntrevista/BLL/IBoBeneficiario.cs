using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public interface IBoBeneficiario
    {
        long Incluir(DML.Beneficiario beneficiario);
        void Excluir(long id);
        List<Beneficiario> Listar(long idCliente);
        bool VerificarExistencia(long IdCliente, string CPF);
    }
}
