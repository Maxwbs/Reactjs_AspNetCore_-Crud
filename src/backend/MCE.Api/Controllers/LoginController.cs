using MCE.Domain.Dtos.Login;
using MCE.Domain.Dtos.Usuario;
using MCE.Domain.Interfaces.Servicos.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IServicoDeLogin _servicoLogin;
        public LoginController(IServicoDeLogin servicoLogin)
        {
            _servicoLogin = servicoLogin;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] DtoLogin dtoLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (dtoLogin == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _servicoLogin.ConsulteLogin(dtoLogin);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
