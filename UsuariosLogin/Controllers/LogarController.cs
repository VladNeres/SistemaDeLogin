using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PraticaLogin.Data;
using PraticaLogin.Service;
using UsuariosLogin.Data.Requests;

namespace PraticaLogin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogarController: ControllerBase
    {
        private readonly LoginService _service;
       
        public LogarController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult LogarlUsuario(LoginRequest request)
        {
            Result resultadoLogin = _service.LogarUsuario(request);
            if (resultadoLogin.IsFailed) return Unauthorized(resultadoLogin.Errors);
            return Ok(resultadoLogin);
        }

        [HttpPost("/solicita-resete")]

        public IActionResult SolicitaReseteSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _service.SolicitareseteSenha(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult EfetuaReset(EfetuaResetRequest request)
        {
            Result resultado = _service.EfetuaReset(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado);
        }

    }
}
