namespace BLL.Errors
{
    public class JwtKeyNotFound : Exception
    {
        public JwtKeyNotFound()
        {
        }

        public JwtKeyNotFound(string message) : base(message)
        {
        }
    }
}