using System.ComponentModel.DataAnnotations;

namespace UsuariosLogin.Data.Requests
{
    public class SolicitaResetRequest
    {
        [Required(ErrorMessage ="Para redefinir a senha é necessario informar o e-mail")]
        public string Email { get; set; } 
    }
}
