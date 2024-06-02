namespace AuthServer.Models
{
    public class AuthCode
    {
        public string ClientId { get; set; }
        public string ReturnUri{ get; set; }
        public string CodeChallenge { get; set; }
        public string CodeChallengeMethod { get; set; }
        public DateTime Expiry { get; set; }
    }
}
