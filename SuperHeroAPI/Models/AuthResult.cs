namespace SuperHeroAPI.Models
{
    public class AuthResult
    {
        public string Token { set; get; }
        public bool Result { set; get; }
        public List<string> Errors { set; get; }


    }
}
