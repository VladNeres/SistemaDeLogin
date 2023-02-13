using System.ComponentModel.DataAnnotations;

namespace UsuariosLogin.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage ="O Campo UserName é obrigatório")]
        [RegularExpression(@"[a-zA-Zá-úÁ-Ú' ']{1,100}", ErrorMessage ="o Campo Username não permite caracteres especiais ou numeros")]
        public string? UserName { get; set; }
       
        [EmailAddress(ErrorMessage ="Formato de Email Invalido")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="O Campo password é obrigatório")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "O campo de repassword é obrigatório")]
        [Compare("Password")]
        public string? Repassword { get; set; }
    }
}
