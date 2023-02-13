using FluentResults;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ess;
using PraticaLogin.Data;
using System.Text.RegularExpressions;
using UsuariosLogin.Data.Requests;
using UsuariosLogin.Models;
using UsuariosLogin.Services;

namespace PraticaLogin.Service
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signing,TokenService service)
        {
            _tokenService = service;
            _signInManager = signing;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var usuarioEmail = _signInManager.UserManager.FindByEmailAsync(request.Email);
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(usuarioEmail.Result.UserName, request.Password, false, false);
           
            if (resultadoIdentity.Result.Succeeded) 
            {
                var IdentityUsuario = _signInManager.UserManager.Users
                    .FirstOrDefault(usuario => usuario.NormalizedEmail == request.Email.ToUpper());
                Token token = _tokenService.CreateToken
                    (IdentityUsuario,_signInManager.UserManager.GetRolesAsync(IdentityUsuario).Result.FirstOrDefault());
                string mensagem = "usuarioLogado com sucesso";

                return Result.Ok().WithSuccess(mensagem); 
            }
              
              return  Result.Fail("Login ou password incorreto"); 
        }

        public Result SolicitareseteSenha(SolicitaResetRequest request)
        {
            IdentityUser<int> userIdentity = RecuperaUsuarioPorEmail(request.Email);

            if (userIdentity != null)
            {
                var tokenDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(userIdentity).Result;
                return Result.Ok().WithSuccess(tokenDeRecuperacao);
            }
            return Result.Fail("Falha ao solicitar a alteração da senha");
        }

        public Result EfetuaReset(EfetuaResetRequest request)
        {
            IdentityUser<int> userIdentity = RecuperaUsuarioPorEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager.UserManager
                .ResetPasswordAsync(userIdentity, request.Token, request.NewPassword).Result;

            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha Redefinida com sucesso!");
            return Result.Fail("falha na redefinição");
        }

        private IdentityUser<int> RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users
                            .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
