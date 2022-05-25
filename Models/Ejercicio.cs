using System;
using System.Collections.Generic;

namespace libreria_api.Models
{
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            Respuesta = new HashSet<Respuestum>();
        }

        public int Id { get; set; }
        public string Enunciado { get; set; } = null!;
        public int IdLibro { get; set; }

        public virtual Libro IdLibroNavigation { get; set; } = null!;
        public virtual ICollection<Respuestum> Respuesta { get; set; }
    }
}
