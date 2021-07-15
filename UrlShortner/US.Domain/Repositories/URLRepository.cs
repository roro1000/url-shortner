using AutoMapper;
using Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class URLRepository : TeenyURLRepository<URL, URLDetails>, IURLRepository
    {
        public URLRepository(TeenyURLContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<URLDetails> AddURLAsync(string longUrl, string shortUrl)
        {
            var url = await AddAsync(new URL
            {
                Code = shortUrl,
                LongValue = longUrl
            });

            return Mapper.Map<URLDetails>(url);
        }

        public async Task<URLDetails> GetByLongURLAsync(string url)
        {
            return await FindAsync(u => u.LongValue == url);
        }

        public async Task<string> GetLongURLAsync(string shortUrl)
        {
            return await Context.URL
                .Where(u => u.Code == shortUrl)
                .Select(u => u.LongValue)
                .FirstOrDefaultAsync();
        }
    }
}
