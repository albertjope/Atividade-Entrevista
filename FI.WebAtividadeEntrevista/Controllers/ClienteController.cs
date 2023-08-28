using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;
using AutoMapper;

namespace WebAtividadeEntrevista.Controllers
{
    public class ClienteController : Controller
    {
        private IMapper mapper;
        private BoCliente _boCliente = new BoCliente();
        private BoBeneficiario _boBeneficiario = new BoBeneficiario();
        public ClienteController()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClienteProfile>();
                cfg.AddProfile<BeneficiarioProfile>();
            });

            mapper = configuration.CreateMapper();
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
                // valida o cpf informado
                if (!_boCliente.VerificarExistencia(model.CPF))
                {
                    model.Id = _boCliente.Incluir(mapper.Map<Cliente>(model));
                    return Json("Cadastro efetuado com sucesso");
                }
                else
                {
                    return Json("Não foi possível efetuar a gravação. O CPF informado já existe na base de dados.");
                }

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
                _boCliente.Alterar(mapper.Map<Cliente>(model));
                return Json("Cadastro alterado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            Cliente cliente = _boCliente.Consultar(id);
            Models.ClienteModel model = null;

            if (cliente != null)
            {
                model = mapper.Map<ClienteModel>(cliente);
            }

            return View(model);
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

                List<Cliente> clientes = _boCliente.Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

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
                
                List<Beneficiario> beneficiarios = _boBeneficiario.Listar(model.Id);

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
                model.Id = _boBeneficiario.Incluir(mapper.Map<Beneficiario>(model));
                return Json("Cadastro efetuado com sucesso");
            }
        }
        [HttpDelete]
        public JsonResult ExcluirBeneficiario(long Id)
        {
            _boBeneficiario.Excluir(Id);
            return Json("Cadastro excluído com sucesso");
        }

    }
}