using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TareaProgramacionlll_filtroDB.Service
{
    public class EventoPendienteService
    {
        public List<EventosPendiente> ObtenerTodos()
        {
            using (var db = new DBContextADO())
            {
                //retorna la tista que creamos en BlogContexModel
                //debemos incluir en este query que queremos obtenerer los comentarios tambien
                return db.EventosPendientesSet.ToList();
            }
        }

        internal void Crear(EventosPendiente model)
        {
            using (var db = new DBContextADO())
            {
                //anadimos el modelo a nuestra lista de blogPost
                db.EventosPendientesSet.Add(model);
                //guardar cambios en la db
                db.SaveChanges();
            }
        }
    }
}