
using System.Threading.Tasks;

namespace TestsApi.Interfaces
{
    public interface IWebDriver
    {
        Task<string> RunDriverClient(string url, string urlParameter, string ApiKey);

        Task<string> RunDriverClient(string url, string urlParameter);

        void StatusTestCode();
    }
}
