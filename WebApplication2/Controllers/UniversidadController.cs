using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.ModelsUniversidad;

namespace WebApplication2.ControllersUniversidad
{
    [ApiController]
    [Route("[controller]")]
    public class UniversidadController : ControllerBase
    {
        private readonly ILogger<UniversidadController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public UniversidadController(
            ILogger<UniversidadController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear universidad
        [HttpPost(Name = "PostUniversidad")]
        public IActionResult Post([FromBody] Universidad universidad)
        {
            _aplicacionContexto.Universidad.Add(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }

        // Read: Obtener lista de universidades
        [HttpGet(Name = "GetUniversidad")]
        public IEnumerable<Universidad> Get()
        {
            return _aplicacionContexto.Universidad.ToList();
        }

        // Update: Modificar universidad
        [HttpPut(Name = "PutUniversidad")]
        public IActionResult Put([FromBody] Universidad universidad)
        {
            _aplicacionContexto.Universidad.Update(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }

        // Delete: Eliminar universidad
        [HttpDelete(Name = "DeleteUniversidad")]
        public IActionResult Delete(int UniversidadId)
        {
            var universidadToDelete = _aplicacionContexto.Universidad
                .FirstOrDefault(x => x.IdUniversidad == UniversidadId);

            if (universidadToDelete != null)
            {
                _aplicacionContexto.Universidad.Remove(universidadToDelete);
                _aplicacionContexto.SaveChanges();
                return Ok(UniversidadId);
            }
            else
            {
                return NotFound($"Universidad con Id {UniversidadId} no encontrada.");
            }
        }
    }
}

