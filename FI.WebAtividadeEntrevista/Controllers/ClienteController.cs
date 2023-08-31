using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;
using AutoMapper;
using WebAtividadeEntrevista.Services.Clientes;

namespace WebAtividadeEntrevista.Controllers
{
    public class ClienteController : Controller
    {
        
        private IServiceCliente _serviceCliente;
        private IServiceBeneficiario _serviceBeneficiario;

        public ClienteController(IServiceBeneficiario serviceBeneficiario, IServiceCliente serviceCliente)
        {
            this._serviceBeneficiario = serviceBeneficiario;
            this._serviceCliente = serviceCliente;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(ClienteModel model)
        {
            
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                if (_serviceCliente.Incluir(model) > 0)
                    return Json("Cadastro efetuado com sucesso");
                else
                    return Json("Não foi possível efetuar a gravação. O CPF informado já existe na base de dados.");

            }
        }

        [HttpPost]
        public JsonResult Alterar(ClienteModel model)
        {
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                try
                {
                    _serviceCliente.Alterar(model);
                    return Json("Cadastro alterado com sucesso");
                }catch (Exception ex)
                {
                    return Json("Não foi possível efetuar a gravação. Ocorreram erros na gravação dos dados.");

                }

            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            ClienteModel cliente = _serviceCliente.Consultar(id);

            return View(cliente);
        }

        [HttpPost]
        public JsonResult ClienteList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<ClienteModel> clientes = _serviceCliente.ListarClientes(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

                //Return result to jTable
                return Json(new { Result = "OK", Records = clientes, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult BeneficiarioList(ClienteModel model)
        {
            try
            {
                List<BeneficiarioModel> beneficiarios = _serviceBeneficiario.ListarBeneficiarios(model.Id);

                //Return result to jTable
                return Json(new { Result = "OK", Records = beneficiarios, TotalRecordCount = beneficiarios.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult IncluirBeneficiario(BeneficiarioModel model)
        {

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                model.Id = _serviceBeneficiario.IncluirBeneficiario(model);
                return Json("Cadastro efetuado com sucesso");
            }
        }
        [HttpDelete]
        public JsonResult ExcluirBeneficiario(long Id)
        {
            _serviceBeneficiario.ExcluirBeneficiario(Id);
            return Json("Cadastro excluído com sucesso");
        }

    }
}