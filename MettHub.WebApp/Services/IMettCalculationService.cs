using System.Threading.Tasks;

namespace MettHub.WebApp.Services
{
    public interface IMettCalculationService
    {
        Task<int> CalculateAsync (int people);
    }
}