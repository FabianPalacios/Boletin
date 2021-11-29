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
    public class MatterController : Controller
    {
        private ImplMatterLogica logica = new ImplMatterLogica();

        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<MatterDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorMatterGUI mapper = new MapeadorMatterGUI();
            IEnumerable<ModeloMatterGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloMatterGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            MatterDTO MatterDTO = logica.BuscarRegistro(id.Value);
            if (MatterDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMatterGUI mapper = new MapeadorMatterGUI();
            ModeloMatterGUI modelo = mapper.MapearTipo1Tipo2(MatterDTO);
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
        public ActionResult Create(ModeloMatterGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMatterGUI mapper = new MapeadorMatterGUI();
                MatterDTO MatterDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(MatterDTO);
                return RedirectToAction("Index");
            }

            ViewBag.Id_Bulletin = new SelectList(logica.ListarRegistroBulletin(), "Id");
            return View(modelo);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatterDTO MatterDTO = logica.BuscarRegistro(id.Value);
            if (MatterDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMatterGUI mapper = new MapeadorMatterGUI();
            ModeloMatterGUI modelo = mapper.MapearTipo1Tipo2(MatterDTO);

            ViewBag.Id_Bulletin = new SelectList(logica.ListarRegistroBulletin(), "Id");
            return View(modelo);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloMatterGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMatterGUI mapper = new MapeadorMatterGUI();
                MatterDTO MatterDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(MatterDTO);
                return RedirectToAction("Index");
            }
            ViewBag.Id_Bulletin = new SelectList(logica.ListarRegistroBulletin(), "Id");
            return View(modelo);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatterDTO MatterDTO = logica.BuscarRegistro(id.Value);
            if (MatterDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMatterGUI mapper = new MapeadorMatterGUI();
            ModeloMatterGUI modelo = mapper.MapearTipo1Tipo2(MatterDTO);
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
                MatterDTO MatterDTO = logica.BuscarRegistro(id);
                if (MatterDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorMatterGUI mapper = new MapeadorMatterGUI();
                ViewBag.mensaje = Mensaje.mensajeErrorEliminar;
                ModeloMatterGUI modelo = mapper.MapearTipo1Tipo2(MatterDTO);
                return View("Delete", modelo);
            }

        }
    }
}
