using APIRestAda.ModelEntry;
using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRestAda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        private readonly IRepositoryGuardar _repositoryGuardar;
        
        public PrincipalController(IRepositoryGuardar repositoryGuardar)
        {
            _repositoryGuardar = repositoryGuardar;
        }

        // POST api/<PrincipalController>
        /// <summary>
        /// Metodo para guardar compañia app y demas
        /// </summary>
        /// <param name="datos"></param>
        [HttpPost("[action]")]
        public IActionResult Post([FromBody] ModelEntryDatos datos)
        {
            Entities.Resultado<List<string>> resultado= new Entities.Resultado< List<string>>();


            int result = _repositoryGuardar.GuardarDatos(datos.codigo_company, datos.name_company, datos.description_company, datos.version, datos.version_description, datos.version_company_description, datos.app_code, datos.app_name, datos.app_description);
            if (result == 1)
            {
                var jsonData = new
                {
                    Mensaje = "Registro creado",
                    Estado = 200
                };
                string _jsonData = JsonConvert.SerializeObject(jsonData);
                JObject jsonObject = JObject.Parse(_jsonData);

                resultado.resultado = new List<string>() { jsonObject.ToString() };
            }
            return Ok(resultado);
        }

      
    }
}
