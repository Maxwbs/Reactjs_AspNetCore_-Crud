using MCE.Domain.Dtos.ParametrizacaoGeral;
using MCE.Domain.Interfaces.Parametrizacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MCE.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParametrizacaoGeralController: ControllerBase
    {
        private IServicoDeParametrizacaoGeral _serviceParametrizacaoCredencialService;

        public ParametrizacaoGeralController(IServicoDeParametrizacaoGeral serviceParametrizacaoCredencialService)
        {
            _serviceParametrizacaoCredencialService = serviceParametrizacaoCredencialService;
        }

        [AllowAnonymous]
        //[Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                return Ok(await _serviceParametrizacaoCredencialService.ObtenhaTodos());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        //[Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DtoParametrizacaoGeral dtoParametrizacaoGeral)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                if (dtoParametrizacaoGeral != null) 
                {                    
                    var resultado = await _serviceParametrizacaoCredencialService.Cadastre(dtoParametrizacaoGeral);
                    if (resultado != null)
                    {
                        return Ok(resultado);
                    }
                }               

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        //[Authorize("Bearer")]
        [HttpPost("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _serviceParametrizacaoCredencialService.DeleteAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
