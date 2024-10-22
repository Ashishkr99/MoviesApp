namespace Authentication.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(string email);
    }
}
