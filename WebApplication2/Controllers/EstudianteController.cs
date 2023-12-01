using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsEstudiante;

namespace WebApplication2.ControllersEstudiante
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly ILogger<EstudianteController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public EstudianteController(
            ILogger<EstudianteController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear email
        [HttpPost(Name = "PostEstudiante")]
        public IActionResult Post([FromBody] Estudiante estudiante)
        {
            _aplicacionContexto.Estudiante.Add(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }

        // Read: Obtener lista de emails
        [HttpGet(Name = "GetEstudiante")]
        public IEnumerable<Estudiante> Get()
        {
            return _aplicacionContexto.Estudiante.ToList();
        }

        // Update: Modificar email
        [HttpPut(Name = "PutEstudiante")]
        public IActionResult Put([FromBody] Estudiante estudiante)
        {
            _aplicacionContexto.Estudiante.Update(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }

        // Delete: Eliminar email
        [HttpDelete(Name = "DeleteEstudiante")]
        public IActionResult Delete(int EstudianteId)
        {
            var estudianteToDelete = _aplicacionContexto.Estudiante
                .FirstOrDefault(x => x.IdEstudiante == EstudianteId);

            if (estudianteToDelete != null)
            {
                _aplicacionContexto.Estudiante.Remove(estudianteToDelete);
                _aplicacionContexto.SaveChanges();
                return Ok(EstudianteId);
            }
            else
            {
                return NotFound($"Estudiante con Id {EstudianteId} no encontrado.");
            }
        }
    }
}
