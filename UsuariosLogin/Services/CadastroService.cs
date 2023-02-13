using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosLogin.Data.Dtos;
using UsuariosLogin.Data.Requests;
using UsuariosLogin.Models;
using UsuariosLogin.Exceptions;
using System.Net.Mail;

namespace UsuariosLogin.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private RoleManager<IdentityRole<int>> _rolerManager;


        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> rolerManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _rolerManager = rolerManager;
        }

        public bool VerificaEmail(string email)
        {
            try
            {
                var validaemail = new MailAddress(email) ;
                return validaemail.Address == email;
            }
            catch
            {
                return false;
            }

        }
        public Result CriarUsuarioPadrao(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var recuperaUsuario = _userManager.Users.FirstOrDefault(u => u.NormalizedUserName == usuarioDto.UserName.ToUpper());
            var recuperaemail = _userManager.Users.FirstOrDefault(u => u.NormalizedEmail == usuarioDto.Email.ToUpper());
            VerificaEmail(usuarioIdentity.Email);


            if (recuperaUsuario != null || recuperaemail!=null)
                throw new AlreadyExists("O usuario ou email ja existe");
            
            var createUserIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);
            var createRoleResult = _rolerManager.CreateAsync(new IdentityRole<int>("padrao")).Result;
            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "padrao").Result;


            if (createUserIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao Cadastrar usuario");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var IdentityUser = _userManager.Users.FirstOrDefault(user => user.Email.ToUpper() ==(request.Email.ToUpper()));
            if (IdentityUser == null)
                throw new NullReferenceException("Usuario não encontrado");

               var identityResult = _userManager.ConfirmEmailAsync(IdentityUser, request.TokenAtivacao).Result;
            if (identityResult.Succeeded) return Result.Ok();

            return Result.Fail("Falha ao ativar a conta do usuario");
        }
    }
}
