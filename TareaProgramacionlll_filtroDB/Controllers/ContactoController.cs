using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaProgramacionlll_filtroDB.Service;

namespace TareaProgramacionlll_filtroDB.Controllers
{
    public class ContactoController : Controller
    {
        //declaraciones
        DBContextADO db;
        private ContactoService _repo;

        //constructor
        public ContactoController()
        {
            db = new DBContextADO();
            _repo = new ContactoService();
        }

        

        // GET: Contacto
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            return View(model);
        }

        // GET: Contacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacto/Create
        [HttpPost]
        public ActionResult Create(Contactos model)
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

        // GET: Contacto/Delete/5
        public ActionResult Delete(Contactos model)
        {
            ViewBag.nombre = model.Nombre;
            return View(model);
        }

        // POST: Contacto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Contactos model)
        {
            using (var db = new DBContextADO())
            {
                 model = (from p in db.ContactosSet
                          where p.Id_contactos == id
                               select p).FirstOrDefault();

                db.ContactosSet.Remove(model);
                db.SaveChanges();
                

                return RedirectToAction("Index", "Contacto");
            }
        }

        //buscar solo el nombre del proveedor ejemplo: /controller/action?nombre_proveedor=angel
        //buacar por el nombre del contacto
        public ActionResult BuscarFiltro_nombre(string Nombre)
        {
                var nombreContacto = from s in db.ContactosSet select s;
                if (!String.IsNullOrEmpty(Nombre))
                {
                    nombreContacto = nombreContacto.Where(j => j.Nombre.Contains(Nombre));
                    
                }
                return View(nombreContacto);
            
           // return View(nombreContacto);
        }


    }
}
