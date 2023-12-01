using Microsoft.EntityFrameworkCore;
using WebApplication2.ModelsEstudiante;
using WebApplication2.ModelsProfesor;
using WebApplication2.ModelsUniversidad;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Universidad> Universidad { get; set; }
    }
}
