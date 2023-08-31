using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DAL.Clientes
{
    public interface IDaoBeneficiario
    {
        long Incluir(DML.Beneficiario beneficiario);
        List<Beneficiario> Listar(long idCliente);
        void Excluir(long Id);
        List<DML.Beneficiario> Converter(DataSet ds);
    }
}
