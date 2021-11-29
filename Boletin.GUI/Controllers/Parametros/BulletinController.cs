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
    public class BulletinController : Controller
    {
        private ImplBulletinLogica logica = new ImplBulletinLogica();

        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<BulletinDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorBulletinGUI mapper = new MapeadorBulletinGUI();
            IEnumerable<ModeloBulletinGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloBulletinGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            BulletinDTO BulletinDTO = logica.BuscarRegistro(id.Value);
            if (BulletinDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorBulletinGUI mapper = new MapeadorBulletinGUI();
            ModeloBulletinGUI modelo = mapper.MapearTipo1Tipo2(BulletinDTO);
            return View(modelo);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {

            ViewBag.Id_Student = new SelectList(logica.ListarRegistroStudent(), "Id", "Documento");
            ViewBag.Id_Grade = new SelectList(logica.ListarRegistroGrade(), "Id", "Degree");
            ViewBag.Id_Period = new SelectList(logica.ListarRegistroPeriod(), "Id", "NumPeriod");
            return View();
        }

        // POST: Marca/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloBulletinGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorBulletinGUI mapper = new MapeadorBulletinGUI();
                BulletinDTO BulletinDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(BulletinDTO);
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
            BulletinDTO BulletinDTO = logica.BuscarRegistro(id.Value);
            if (BulletinDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorBulletinGUI mapper = new MapeadorBulletinGUI();
            ModeloBulletinGUI modelo = mapper.MapearTipo1Tipo2(BulletinDTO);

            ViewBag.Id_Student = new SelectList(logica.ListarRegistroStudent(), "Id", "Documento");
            ViewBag.Id_Grade = new SelectList(logica.ListarRegistroGrade(), "Id", "Degree");
            ViewBag.Id_Period = new SelectList(logica.ListarRegistroPeriod(), "Id", "NumPeriod");
            return View(modelo);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloBulletinGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorBulletinGUI mapper = new MapeadorBulletinGUI();
                BulletinDTO BulletinDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(BulletinDTO);
                return RedirectToAction("Index");
            }

            ViewBag.Id_Student = new SelectList(logica.ListarRegistroStudent(), "Id", "Documento");
            ViewBag.Id_Grade = new SelectList(logica.ListarRegistroGrade(), "Id", "Degree");
            ViewBag.Id_Period = new SelectList(logica.ListarRegistroPeriod(), "Id", "NumPeriod");
            return View(modelo);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinDTO BulletinDTO = logica.BuscarRegistro(id.Value);
            if (BulletinDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorBulletinGUI mapper = new MapeadorBulletinGUI();
            ModeloBulletinGUI modelo = mapper.MapearTipo1Tipo2(BulletinDTO);
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
                BulletinDTO BulletinDTO = logica.BuscarRegistro(id);
                if (BulletinDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorBulletinGUI mapper = new MapeadorBulletinGUI();
                ViewBag.mensaje = Mensaje.mensajeErrorEliminar;
                ModeloBulletinGUI modelo = mapper.MapearTipo1Tipo2(BulletinDTO);
                return View("Delete", modelo);
            }

        }
    }
}
