using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsProfesor
{
    public class Profesor
    {
        [Key]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ubicacion { get; set; }
        public bool Sexo { get; set; }
        public int IdUniversidad { get; set; }


    }
}