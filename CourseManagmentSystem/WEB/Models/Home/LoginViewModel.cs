using App.Shared.ReturnObjects;

namespace WEB.Models.Home
{
    public class LoginViewModel
    {
        public string Username;
        public string Password;
        public Result Result;

        public LoginViewModel(string username, string password, Result result = null)
        {
            Username = username;
            Password = password;
            Result = result;
        }
    }
}
