using Instrumentos.Models;
using Instrumentos.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Instrumentos.Controllers
{
    public class TipoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet] //Abre a página
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost] //Cadastra no banco de dados
        public ActionResult Cadastrar(Tipo tipo)
        {
            //Cadastra no banco
            _unit.TipoRepository.Cadastrar(tipo);
            _unit.Salvar();
            //Mensagem de sucesso
            TempData["msg"] = "Tipo Cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();  //Fecha a conexão com o BD
            base.Dispose(disposing);
        }
    }
}