using FI.AtividadeEntrevista.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario : IBoBeneficiario
    {
        private DaoBeneficiario _daoBeneficiario = new DaoBeneficiario();

        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        /// <param name="beneficiario">Objeto de cliente</param>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            return _daoBeneficiario.Incluir(beneficiario);
        }

        /// <summary>
        /// Excluir o beneficiário pelo id
        /// </summary>
        /// <param name="id">id do beneficiário</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            _daoBeneficiario.Excluir(id);
        }

        /// <summary>
        /// Lista os beneficiários
        /// </summary>
        public List<DML.Beneficiario> Listar(long idCliente)
        {
            return _daoBeneficiario.Listar(idCliente);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(long IdCliente, string CPF)
        {
            
            return _daoBeneficiario.Listar(IdCliente).Where(x=>x.CPF == CPF).ToList().Count > 0;
        }

    }
}
