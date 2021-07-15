using Domain.Interfaces;
using Domain.Entities;
using Domain.Models;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;

namespace Domain
{
    public class URLRepository : TeenyURLRepository<URL, URLDetails>, IURLRepository
    {
        private readonly IHttpContextAccessor _httpContext;
        public URLRepository(TeenyURLContext context, IMapper mapper, IHttpContextAccessor httpContext) : base(context, mapper) 
        {
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        }

        public async Task<URLDetails> AddURLAsync(string longUrl, string shortUrl)
        {
            var url = await AddAsync(new URL
            {
                ShortValue = shortUrl,
                LongValue = longUrl
            });

            return Mapper.Map<URLDetails>(url);
        }

        public async Task<URLDetails> GetByLongURLAsync(string url)
        {
            return await FindAsync(u => u.LongValue == url);
        }

        public string GetBaseUrl()
        {
            return $"https://{_httpContext.HttpContext.Request.Host}";
        }
    }
}
