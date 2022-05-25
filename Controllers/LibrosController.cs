

namespace libreria_api.Controllers
{
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly libreriaContext db;

        public LibrosController(libreriaContext contexto)
        {
            db = contexto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await db.Libros.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Libro libro)
        {
            db.Add(libro);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromQuery] int idLibro, [FromBody] Libro libro)
        {
            if (idLibro != libro.Id)
            {
                return BadRequest();
            }

            var oldLibro = await db.Libros.FindAsync(idLibro);
            if (oldLibro == null)
            {
                return NotFound();
            }

            oldLibro.Titulo = libro.Titulo;
            await db.SaveChangesAsync();
            return Ok(oldLibro);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int idLibro)
        {
            var oldLibro = await db.Libros.FindAsync(idLibro);
            if (oldLibro == null)
            {
                return NotFound();
            }
            db.Libros.Remove(oldLibro);

            await db.SaveChangesAsync();
            return Ok(new { message = $"Libro {oldLibro.Titulo} borrado" });
        }
    }
}