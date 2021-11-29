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
    public class StudentController : Controller
    {
        private ImplStudentLogica logica = new ImplStudentLogica();

        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;
            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<StudentDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorStudentGUI mapper = new MapeadorStudentGUI();
            IEnumerable<ModeloStudentGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);

            //var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloStudentGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            StudentDTO StudentDTO = logica.BuscarRegistro(id.Value);
            if (StudentDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorStudentGUI mapper = new MapeadorStudentGUI();
            ModeloStudentGUI modelo = mapper.MapearTipo1Tipo2(StudentDTO);
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
        public ActionResult Create(ModeloStudentGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorStudentGUI mapper = new MapeadorStudentGUI();
                StudentDTO StudentDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(StudentDTO);
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
            StudentDTO StudentDTO = logica.BuscarRegistro(id.Value);
            if (StudentDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorStudentGUI mapper = new MapeadorStudentGUI();
            ModeloStudentGUI modelo = mapper.MapearTipo1Tipo2(StudentDTO);
            return View(modelo);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloStudentGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorStudentGUI mapper = new MapeadorStudentGUI();
                StudentDTO StudentDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(StudentDTO);
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
            StudentDTO StudentDTO = logica.BuscarRegistro(id.Value);
            if (StudentDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorStudentGUI mapper = new MapeadorStudentGUI();
            ModeloStudentGUI modelo = mapper.MapearTipo1Tipo2(StudentDTO);
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
                StudentDTO StudentDTO = logica.BuscarRegistro(id);
                if (StudentDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorStudentGUI mapper = new MapeadorStudentGUI();
                ViewBag.mensaje = Mensaje.mensajeErrorEliminar;
                ModeloStudentGUI modelo = mapper.MapearTipo1Tipo2(StudentDTO);
                return View("Delete", modelo);
            }

        }
    }
}
