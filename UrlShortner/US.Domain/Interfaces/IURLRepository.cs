using System.Threading.Tasks;
using Domain.Entities;
using Common.Models;

namespace Domain.Interfaces
{
    public interface IURLRepository : ITeenyURLRepository<URL, URLDetails>
    {
        Task<URLDetails> AddURLAsync(string longUrl, string shortUrl);
        Task<URLDetails> GetByLongURLAsync(string url);
        Task<string> GetLongURLAsync(string shortUrl);
    }
}
