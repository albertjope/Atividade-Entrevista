using FI.AtividadeEntrevista.DML;
using System.Collections.Generic;


namespace FI.AtividadeEntrevista.BLL
{
    public interface IBoCliente
    {
        long Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
        Cliente Consultar(long id);
        void Excluir(long id);
        List<Cliente> Listar();
        List<Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd);
        bool VerificarExistencia(string CPF);
    }
}
