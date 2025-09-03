namespace MeuCorre.Infra
{
    public interface IConfiguration
    {
        string GetConnectionString(string v);
    }
}