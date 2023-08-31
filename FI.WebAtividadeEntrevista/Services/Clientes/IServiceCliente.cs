
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Services.Clientes
{
    public interface IServiceCliente
    {
        void Alterar(ClienteModel model);
        ClienteModel Consultar(long id);
        List<ClienteModel> ListarClientes (int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd);
        long Incluir(ClienteModel cliente);
    }
}