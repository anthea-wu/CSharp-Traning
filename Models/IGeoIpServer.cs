namespace CSharp_Traning.Models
{
    public interface IGeoIpServer
    {
        string GetCurrentIP();
        string GetCurrentCountry(string ip);
    }
}