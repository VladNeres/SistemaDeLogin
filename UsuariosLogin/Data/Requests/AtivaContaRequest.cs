using System.ComponentModel.DataAnnotations;

namespace UsuariosLogin.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required(ErrorMessage ="O campo Token  é obrigatorio")]
        public string TokenAtivacao { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
