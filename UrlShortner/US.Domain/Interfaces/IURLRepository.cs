using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IURLRepository : ITeenyURLRepository<URL, URLDetails>
    {
        Task<URLDetails> GetByLongURLAsync(string url);
        Task<URLDetails> AddURLAsync(string longUrl, string shortUrl);
        string GetBaseUrl();
    }
}
