using System;
using System.Collections.Generic;

namespace libreria_api.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Ejercicios = new HashSet<Ejercicio>();
        }

        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public virtual ICollection<Ejercicio> Ejercicios { get; set; }
    }
}
