namespace Inforce.BLL.Util.Options;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public double LifetimeInHours { get; set; }
}