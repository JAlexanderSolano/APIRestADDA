using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRestAda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        
        private readonly IRepositoryActualizar _repositoryActualizar;
        private readonly IRepositoryEliminar _repositoryEliminar;

        public CompanyController(IRepositoryActualizar repositoryActualizar, IRepositoryEliminar repositoryEliminar)
        {
            _repositoryActualizar = repositoryActualizar;
            _repositoryEliminar = repositoryEliminar;
        }

        // GET api/<CompanyController>/5
        /// <summary>
        /// Obtener registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Obtener todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetTodos()
        {
            return Ok();
        }

        // PUT api/<CompanyController>/5
        /// <summary>
        /// Actualizar registro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<CompanyController>/5
        /// <summary>
        /// Eliminar registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            return Ok();
        }
    }
}
