using System.Threading.Tasks;
using Domain.Models;

namespace Services.Interfaces
{
    public interface IURLService
    {
        Task<URLDetails> AddShortURL(string longUrl);
    }
}
