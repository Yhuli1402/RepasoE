using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsProfesor;

namespace WebApplication2.ControllersProfesor
{
    [ApiController]
    [Route("[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly ILogger<ProfesorController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public ProfesorController(
            ILogger<ProfesorController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear profesor
        [HttpPost(Name = "PostProfesor")]
        public IActionResult Post([FromBody] Profesor profesor)
        {
            _aplicacionContexto.Profesor.Add(profesor);
            _aplicacionContexto.SaveChanges();
            return Ok(profesor);
        }

        // Read: Obtener lista de profesores
        [HttpGet(Name = "GetProfesor")]
        public IEnumerable<Profesor> Get()
        {
            return _aplicacionContexto.Profesor.ToList();
        }

        // Update: Modificar profesor
        [HttpPut(Name = "PutProfesor")]
        public IActionResult Put([FromBody] Profesor profesor)
        {
            _aplicacionContexto.Profesor.Update(profesor);
            _aplicacionContexto.SaveChanges();
            return Ok(profesor);
        }

        // Delete: Eliminar profesor
        [HttpDelete(Name = "DeleteProfesor")]
        public IActionResult Delete(int ProfesorId)
        {
            var profesorToDelete = _aplicacionContexto.Profesor
                .FirstOrDefault(x => x.IdProfesor == ProfesorId);

            if (profesorToDelete != null)
            {
                _aplicacionContexto.Profesor.Remove(profesorToDelete);
                _aplicacionContexto.SaveChanges();
                return Ok(ProfesorId);
            }
            else
            {
                return NotFound($"Profesor con Id {ProfesorId} no encontrado.");
            }
        }
    }
}
