using Entities;

namespace BussinessLayer
{
    public class TokenResponse
    {
        public Person User { get; set; }
        public string RefreshToken { get; set; }
    }
}