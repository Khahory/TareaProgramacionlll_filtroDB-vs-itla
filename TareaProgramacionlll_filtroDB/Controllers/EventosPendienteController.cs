using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaProgramacionlll_filtroDB.Service;

namespace TareaProgramacionlll_filtroDB.Controllers
{
    public class EventosPendienteController : Controller
    {
        //declaraciones
        DBContextADO db;
        private EventoPendienteService _repo;

        public EventosPendienteController()
        {
            db = new DBContextADO();
            _repo = new EventoPendienteService();
        }

        // GET: EventosPendiente
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            return View(model);
        }

        // GET: EventosPendiente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacto/Create
        [HttpPost]
        public ActionResult Create(EventosPendiente model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //este modelo se enviara a crear, luego se enviara al MODELO de BlogPostModel (y despues de ahi a la DB)
                    _repo.Crear(model);

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                //log ex
            }
            return View(model);
        }


        // GET: EventosPendiente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventosPendiente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventosPendiente model)
        {
            using (var db = new DBContextADO())
            {
                model = (from p in db.EventosPendientesSet
                         where p.Id_eventoPendiente == id
                         select p).FirstOrDefault();

                db.EventosPendientesSet.Remove(model);
                db.SaveChanges();


                return RedirectToAction("Index", "EventosPendiente");
            }
        }

        //buscar solo el nombre del proveedor ejemplo: /controller/action?nombre_proveedor=angel
        //buacar por el nombre del contacto
        public ActionResult BuscarFiltro_fecha(string Fecha_inicial)
        {
            var fecha = from s in db.EventosPendientesSet select s;
            //string x = Fecha_inicial.ToString();

            if (!String.IsNullOrEmpty(Fecha_inicial))
            {
           //     DateTime ff = DateTime.Parse(Fecha_inicial);      podemos poner esto para trabajar con un atributo tipo date  
                fecha = fecha.Where(j => j.Fecha_inicial.Contains(Fecha_inicial));

            }
            return View(fecha);

            // return View(nombreContacto);
        }


    }
}
