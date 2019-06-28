using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TareaProgramacionlll_filtroDB.Service
{
    public class ContactoService
    {
            public List<Contactos> ObtenerTodos()
            {
                using (var db = new DBContextADO())
                {
                    //retorna la tista que creamos en BlogContexModel
                    //debemos incluir en este query que queremos obtenerer los comentarios tambien
                    return db.ContactosSet.ToList();
                }
            }

            internal void Crear(Contactos model)
            {
                using (var db = new DBContextADO())
                {
                    //anadimos el modelo a nuestra lista de blogPost
                    db.ContactosSet.Add(model);
                    //guardar cambios en la db
                    db.SaveChanges();
                }
            }

        internal void Eliminar(Contactos model)
        {
            using (var db = new DBContextADO())
            {
                //anadimos el modelo a nuestra lista de blogPost
                db.ContactosSet.Remove(model);
                //guardar cambios en la db
                db.SaveChanges();
            }
        }

    }
}