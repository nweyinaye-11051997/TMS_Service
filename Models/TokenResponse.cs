namespace TaskManagementSystem.Models
{
    public class TokenResponse
    {
        public string code { get; set; }
        public string username { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
