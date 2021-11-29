using Boletin.GUI.Helpers;
using Boletin.GUI.Mapeadores.Parametros;
using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Boletin.GUI.Controllers.Parametros
{
    public class GradeController : Controller
    {
        private ImplGradeLogica logica = new ImplGradeLogica();

        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<GradeDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorGradeGUI mapper = new MapeadorGradeGUI();
            IEnumerable<ModeloGradeGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloGradeGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            GradeDTO GradeDTO = logica.BuscarRegistro(id.Value);
            if (GradeDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorGradeGUI mapper = new MapeadorGradeGUI();
            ModeloGradeGUI modelo = mapper.MapearTipo1Tipo2(GradeDTO);
            return View(modelo);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloGradeGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorGradeGUI mapper = new MapeadorGradeGUI();
                GradeDTO GradeDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(GradeDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeDTO GradeDTO = logica.BuscarRegistro(id.Value);
            if (GradeDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorGradeGUI mapper = new MapeadorGradeGUI();
            ModeloGradeGUI modelo = mapper.MapearTipo1Tipo2(GradeDTO);
            return View(modelo);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloGradeGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorGradeGUI mapper = new MapeadorGradeGUI();
                GradeDTO GradeDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(GradeDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeDTO GradeDTO = logica.BuscarRegistro(id.Value);
            if (GradeDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorGradeGUI mapper = new MapeadorGradeGUI();
            ModeloGradeGUI modelo = mapper.MapearTipo1Tipo2(GradeDTO);
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
                GradeDTO GradeDTO = logica.BuscarRegistro(id);
                if (GradeDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorGradeGUI mapper = new MapeadorGradeGUI();
                ViewBag.mensaje = Mensaje.mensajeErrorEliminar;
                ModeloGradeGUI modelo = mapper.MapearTipo1Tipo2(GradeDTO);
                return View("Delete", modelo);
            }

        }
    }
}