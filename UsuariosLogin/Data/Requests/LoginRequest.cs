using System.ComponentModel.DataAnnotations;

namespace PraticaLogin.Data
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="Email e obrigatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="password e obrigatorio")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
