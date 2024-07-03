namespace BLL.Errors
{
    public class UserLoginNotFound : Exception
    {
        public UserLoginNotFound()
        {
        }

        public UserLoginNotFound(string message) : base(message)
        {
        }
    }
}