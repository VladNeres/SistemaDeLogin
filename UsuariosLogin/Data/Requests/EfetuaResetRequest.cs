using System.ComponentModel.DataAnnotations;

namespace UsuariosLogin.Data.Requests
{
    public class EfetuaResetRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
