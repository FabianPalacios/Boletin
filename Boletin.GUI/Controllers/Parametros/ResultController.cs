using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boletin.GUI.Helpers;
using Boletin.GUI.Mapeadores.Parametros;
using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using PagedList;

namespace Boletin.GUI.Controllers.Parametros
{
    public class ResultController : Controller
    {
        private ImplResultLogica logica = new ImplResultLogica();

        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<ResultDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorResultGUI mapper = new MapeadorResultGUI();
            IEnumerable<ModeloResultGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloResultGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ResultDTO ResultDTO = logica.BuscarRegistro(id.Value);
            if (ResultDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorResultGUI mapper = new MapeadorResultGUI();
            ModeloResultGUI modelo = mapper.MapearTipo1Tipo2(ResultDTO);
            return View(modelo);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {

            ViewBag.Id_Matter = new SelectList(logica.ListarRegistroMatter(), "Id", "Name");
            return View();
        }

        // POST: Marca/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloResultGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorResultGUI mapper = new MapeadorResultGUI();
                ResultDTO ResultDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(ResultDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Id_Matter = new SelectList(logica.ListarRegistroMatter(), "Id", "Name");
            return View(modelo);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultDTO ResultDTO = logica.BuscarRegistro(id.Value);
            if (ResultDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorResultGUI mapper = new MapeadorResultGUI();
            ModeloResultGUI modelo = mapper.MapearTipo1Tipo2(ResultDTO);
            ViewBag.Id_Matter = new SelectList(logica.ListarRegistroMatter(), "Id", "Name");
            return View(modelo);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloResultGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorResultGUI mapper = new MapeadorResultGUI();
                ResultDTO ResultDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ResultDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Id_Matter = new SelectList(logica.ListarRegistroMatter(), "Id", "Name");
            return View(modelo);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultDTO ResultDTO = logica.BuscarRegistro(id.Value);
            if (ResultDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorResultGUI mapper = new MapeadorResultGUI();
            ModeloResultGUI modelo = mapper.MapearTipo1Tipo2(ResultDTO);
            return View(modelo);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ResultDTO ResultDTO = logica.BuscarRegistro(id);
                if (ResultDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorResultGUI mapper = new MapeadorResultGUI();
                ViewBag.mensaje = Mensaje.mensajeErrorEliminar;
                ModeloResultGUI modelo = mapper.MapearTipo1Tipo2(ResultDTO);
                return View("Delete", modelo);
            }

        }
    }
}
