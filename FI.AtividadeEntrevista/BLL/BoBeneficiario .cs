using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de cliente</param>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario beneficiarioDao = new DAL.DaoBeneficiario();
            return beneficiarioDao.Incluir(beneficiario);
        }

        /// <summary>
        /// Excluir o beneficiário pelo id
        /// </summary>
        /// <param name="id">id do beneficiário</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoBeneficiario beneficiarioDao = new DAL.DaoBeneficiario();
            beneficiarioDao.Excluir(id);
        }

        /// <summary>
        /// Lista os beneficiários
        /// </summary>
        public List<DML.Beneficiario> Listar(long idCliente)
        {
            DAL.DaoBeneficiario beneficiarioDao = new DAL.DaoBeneficiario();
            return beneficiarioDao.Listar(idCliente);
        }

    }
}
