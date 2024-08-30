using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRestAda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        private readonly IRepositoryGuardar _repositoryGuardar;
        public PrincipalController() 
        {
            
        }
        // POST api/<PrincipalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

      
    }
}
