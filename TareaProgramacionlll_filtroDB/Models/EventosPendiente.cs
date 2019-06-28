namespace TareaProgramacionlll_filtroDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventosPendiente")]
    public partial class EventosPendiente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_eventoPendiente { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre_evento { get; set; }

        [Required]
        //[Column(TypeName = "date")]
        [StringLength(30)]
        public string Fecha_inicial { get; set; }

        [Required]
        [StringLength(60)]
        public string Lugar { get; set; }
    }
}
