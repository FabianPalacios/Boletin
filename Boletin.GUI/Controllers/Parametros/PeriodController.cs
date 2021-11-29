using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boletin.GUI.Models.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using Boletin.GUI.Helpers;
using LogicaNegocio.DTO.Parametros;
using Boletin.GUI.Mapeadores.Parametros;
using PagedList;

namespace Boletin.GUI.Controllers.Parametros
{
    public class PeriodController : Controller
    {
        private ImplPeriodLogica logica = new ImplPeriodLogica();

        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<PeriodDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorPeriodGUI mapper = new MapeadorPeriodGUI();
            IEnumerable<ModeloPeriodGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloPeriodGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PeriodDTO PeriodDTO = logica.BuscarRegistro(id.Value);
            if (PeriodDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPeriodGUI mapper = new MapeadorPeriodGUI();
            ModeloPeriodGUI modelo = mapper.MapearTipo1Tipo2(PeriodDTO);
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
        public ActionResult Create(ModeloPeriodGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorPeriodGUI mapper = new MapeadorPeriodGUI();
                PeriodDTO PeriodDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(PeriodDTO);
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
            PeriodDTO PeriodDTO = logica.BuscarRegistro(id.Value);
            if (PeriodDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPeriodGUI mapper = new MapeadorPeriodGUI();
            ModeloPeriodGUI modelo = mapper.MapearTipo1Tipo2(PeriodDTO);
            return View(modelo);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloPeriodGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorPeriodGUI mapper = new MapeadorPeriodGUI();
                PeriodDTO PeriodDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(PeriodDTO);
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
            PeriodDTO PeriodDTO = logica.BuscarRegistro(id.Value);
            if (PeriodDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPeriodGUI mapper = new MapeadorPeriodGUI();
            ModeloPeriodGUI modelo = mapper.MapearTipo1Tipo2(PeriodDTO);
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
                PeriodDTO PeriodDTO = logica.BuscarRegistro(id);
                if (PeriodDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorPeriodGUI mapper = new MapeadorPeriodGUI();
                ViewBag.mensaje = Mensaje.mensajeErrorEliminar;
                ModeloPeriodGUI modelo = mapper.MapearTipo1Tipo2(PeriodDTO);
                return View("Delete", modelo);
            }

        }
    }
}
