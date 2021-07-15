using System.Threading.Tasks;
using Common.Models;

namespace Services.Interfaces
{
    public interface IURLService
    {
        Task<URLDetails> AddShortURL(string longUrl);
        Task<string> GetLongURL(string shortURL);
    }
}
