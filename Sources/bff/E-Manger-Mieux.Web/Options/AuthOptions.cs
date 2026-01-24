namespace Options;

public class AuthOptions
{
    public const string Auth = "Auth";
    public string Authority { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
}
