namespace UsuariosLogin.Models
{
    public class Token
    {
        public string Value { get; }
        public Token(string token)
        {
            Value = token;
        }
    }
}
