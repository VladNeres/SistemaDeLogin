using System.ComponentModel.DataAnnotations;

namespace UsuariosLogin.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage =" o campo e-mail é obrigatório")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="O campo senha é obrigatório")]
        public string Email { get; set; }
    }
}
