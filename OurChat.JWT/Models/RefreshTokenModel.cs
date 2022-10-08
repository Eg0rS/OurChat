namespace OurChat.JWT.Models;

public class RefreshTokenModel
{
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}