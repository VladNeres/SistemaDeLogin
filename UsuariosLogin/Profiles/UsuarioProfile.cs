using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosLogin.Data.Dtos;
using UsuariosLogin.Models;

namespace UsuariosLogin.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
