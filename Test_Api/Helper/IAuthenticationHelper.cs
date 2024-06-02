namespace Test_Api.Helper
{
    public interface IAuthenticationHelper
    {
        string Authenticate(string username, string password);

        IDictionary<string, Tuple<string, string>> Tokens { get; }
    }
}
