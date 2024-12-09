namespace SyntaxErrorist.Core
{
    public class AuthResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        //public string RefreshToken { get; set; }
        //public DateTime TokenExpiration { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();

    }
}
