namespace BLL.Errors
{
    public class UserPasswordError : Exception
    {
        public UserPasswordError()
        {
        }

        public UserPasswordError(string message) : base(message)
        {
        }
    }
}