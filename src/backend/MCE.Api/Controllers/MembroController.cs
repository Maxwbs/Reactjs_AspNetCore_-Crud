using MCE.Domain.Dtos;
using MCE.Domain.Interfaces.Membro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MCE.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembroController : ControllerBase
    {
        private readonly IServicoDeMembro _servicoDeMembro;

        public MembroController(IServicoDeMembro servicoDeMembro)
        {
            _servicoDeMembro = servicoDeMembro;
        }

        //[Authorize("Bearer")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                return Ok(await _servicoDeMembro.ObtenhaTodos());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

       // [Authorize("Bearer")]
        [AllowAnonymous]
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _servicoDeMembro.ObtenhaPorId(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(Guid id, [FromBody] DtoMembro membro)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                var resultado = await _servicoDeMembro.Cadastre(membro);
                if (resultado != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = resultado.Id })), resultado);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] DtoMembro membro)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var resultado = await _servicoDeMembro.Atualize(membro);
                if (resultado != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = resultado.Id })), resultado);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                return Ok(await _servicoDeMembro.Exclua(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
    }
}
