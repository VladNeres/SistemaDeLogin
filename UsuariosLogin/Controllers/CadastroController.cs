using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using UsuariosLogin.Data.Dtos;
using UsuariosLogin.Data.Requests;
using UsuariosLogin.Exceptions;
using UsuariosLogin.Services;

namespace UsuariosLogin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService _service;
        public CadastroController(CadastroService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CriandoUsuarioPadrao(CreateUsuarioDto usuarioDto)
        {
            try
            {

                Result resultado = _service.CriarUsuarioPadrao(usuarioDto);
                if (resultado.IsFailed) return StatusCode(500);
                return Ok(resultado.Successes);
            }
            catch(AlreadyExists e)
            {
               return BadRequest(e.Message);
            }
        }


        [HttpPost("/ativa")]

        public IActionResult AtivaContaUsuario(AtivaContaRequest request)
        {
            try
            {
                Result resultado = _service.AtivaContaUsuario(request);
                if (resultado.IsFailed) return StatusCode(500);
                return Ok(resultado.IsSuccess);
            }
            catch(NullReferenceException e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}
