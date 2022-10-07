namespace OurChat.Models.DomainModels;

public class JWTResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}