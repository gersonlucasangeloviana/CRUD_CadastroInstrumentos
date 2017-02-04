using Instrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Instrumentos.Controllers
{
    public class InstrumentoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Instrumento
        [HttpGet]
        public ActionResult Cadastrar()
        {
            CarregarTipos();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Instrumento i)
        {
            if (ModelState.IsValid)
            {
                _unit.InstrumentoRepository.Cadastrar(i);
                _unit.Salvar();
                TempData["msg"] = "Instrumento Cadastrado";
                return RedirectToAction("Cadastrar");
            } else
            {
                CarregarTipos();
                return View(i);
            }
        }

        public ActionResult Excluir(int id)
        {
            _unit.InstrumentoRepository.Remover(id);
            _unit.Salvar();
            TempData["msg"] = "Instrumento Excluido";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Editar(Instrumento  instrumento)
        {
            if (ModelState.IsValid)
            {
                _unit.InstrumentoRepository.Atualizar(instrumento);
                _unit.Salvar();
                TempData["msg"] = "Instrumento atualizado";
                return RedirectToAction("Listar");
            }
            else
            {
                CarregarTipos();
                return View(instrumento);
            }
        }

        [HttpGet] //Abre a tela com o formulário preenchido
        public ActionResult Editar(int id)
        {
            CarregarTipos();
            //buscar o carro no banco
            var instrumento = _unit.InstrumentoRepository.Consultar(id);
            //Passa o carro para a tela
            return View(instrumento);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //Buscar os carros do banco de dados
            var instrumentos = _unit.InstrumentoRepository.Listar();
            return View(instrumentos);
        }

        private void CarregarTipos()
        {
            var lista = _unit.TipoRepository.Listar();
            ViewBag.tipos = new SelectList(lista, "TipoId", "Descricao");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }

    }
}
