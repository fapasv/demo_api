using System;
using System.Collections.Generic;

namespace libreria_api.Models
{
    public partial class Respuestum
    {
        public int IdEjercicio { get; set; }
        public int IdUsuario { get; set; }
        public string Valor { get; set; } = null!;

        public virtual Ejercicio IdEjercicioNavigation { get; set; } = null!;
    }
}
