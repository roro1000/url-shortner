using Common.Models;
using Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class URLService : IURLService
    {
        private readonly IURLRepository _repository;
        private readonly Random _random;
        public URLService(IURLRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _random = new Random();
        }

        public async Task<URLDetails> AddShortURL(string longUrl)
        {
            var url = await _repository.GetByLongURLAsync(longUrl);

            if (url == null)
            {
                var shortUrl = await CreateCode();
                return await _repository.AddURLAsync(longUrl, shortUrl);
            }

            return url;
        }

        public async Task<string> GetLongURL(string shortURL)
        {
            return await _repository.GetLongURLAsync(shortURL);
        }

        private async Task<string> CreateCode()
        {
            var value = GetRandomString();
            var exists = true;

            // continously generates until it is not found in the db
            while (exists)
            {
                value = GetRandomString();
                exists = await _repository.ExistsAsync(u => u.Code == value);
            }

            return value;
        }

        private string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[_random.Next(s.Length)])
                          .ToArray());
        }
    }
}
