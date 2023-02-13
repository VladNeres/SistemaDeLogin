namespace UsuariosLogin.Exceptions
{
    public class AlreadyExists:Exception
    {
        private const string Message = "O objeto já existe";
        public AlreadyExists():base(Message)
        {

        }
        public AlreadyExists(string mensagem):base(mensagem)
        {

        }

        public AlreadyExists(Exception innerexception): base(Message, innerexception)
        {

        }
    }
}
