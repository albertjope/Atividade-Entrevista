using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.DAL.Clientes
{
    public interface IDaoCliente
    {
        long Incluir(Cliente cliente);
        Cliente Consultar(long Id);
        bool VerificarExistencia(string CPF);
        List<Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd);
        List<Cliente> Listar();
        void Alterar(Cliente cliente);
        void Excluir(long Id);
        List<DML.Cliente> Converter(DataSet ds);
    }
}
