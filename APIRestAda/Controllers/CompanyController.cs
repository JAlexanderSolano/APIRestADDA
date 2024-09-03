using APIRestAda.ModelEntry;
using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRestAda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        
        private readonly IRepositoryActualizar _repositoryActualizar;
        private readonly IRepositoryEliminar _repositoryEliminar;
        private readonly IRepositoryConsultar _repositoryConsultar;

        public CompanyController(IRepositoryActualizar repositoryActualizar, IRepositoryEliminar repositoryEliminar, IRepositoryConsultar repositoryConsultar)
        {
            _repositoryActualizar = repositoryActualizar;
            _repositoryEliminar = repositoryEliminar;
            _repositoryConsultar = repositoryConsultar;
        }

        // GET api/<CompanyController>/5
        /// <summary>
        /// Obtener registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetPorId(int id)
        {
            DataTable tblResult = _repositoryConsultar.ObtenerCompany(id);
            List<Entities.companyResult> lsresult = new List<Entities.companyResult>();

            if(tblResult.Rows.Count > 0)
            {
                string ?codigo_company = "", name_company = "", app_name = "", version = "";

                foreach(DataRow fila in tblResult.Rows)
                {
                    codigo_company = fila["codigo_company"].ToString();
                    name_company = fila["name_company"].ToString();
                    app_name = fila["app_name"].ToString();
                    version = fila["version"].ToString();

                    lsresult.Add(new Entities.companyResult(codigo_company, name_company, app_name, version) { });
                }
            }

            return Ok(lsresult);

        }

        // PUT api/<CompanyController>/5
        /// <summary>
        /// Actualizar registro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public IActionResult Actualizar(int id, [FromBody] ModelEntryCompany mec)
        {
            Entities.Resultado<List<string>> resultado = new Entities.Resultado<List<string>>();

            int result = _repositoryActualizar.ActualizarCompamia(id, mec.codigo_company, mec.name_company, mec.description_company);

            if (result == 1)
            {
                var jsonData = new
                {
                    Mensaje = "La compañia ha sido actualizada con exito",
                    Estado = 200
                };
                string _jsonData = JsonConvert.SerializeObject(jsonData);
                JObject jsonObject = JObject.Parse(_jsonData);

                resultado.resultado = new List<string>() { jsonObject.ToString() };
            }

            return Ok(resultado);
        }

        // DELETE api/<CompanyController>/5
        /// <summary>
        /// Eliminar registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public IActionResult Eliminar(int id)
        {

            Entities.Resultado<List<string>> resultado = new Entities.Resultado<List<string>>();

            int result = _repositoryEliminar.EliminarDatos(id);

            if (result == 1)
            {
                var jsonData = new
                {
                    Mensaje = "Datos eliminados con exito",
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
