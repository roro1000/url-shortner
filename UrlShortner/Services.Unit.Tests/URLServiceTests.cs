using Domain.Entities;
using Moq;
using Services.Unit.Tests.Fakes;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Services.Unit.Tests
{
    public class URLServiceTests
    {
        private readonly FakeURLRepository _urlRepo;

        public URLServiceTests()
        {
            _urlRepo = new FakeURLRepository();
        }

        [Fact]
        public async Task CreateShortURL_ShouldAddURL()
        {
            var service = new URLService(_urlRepo.Object);
            var longUrl = "www.test.com";
            var url = await service.AddShortURL(longUrl);

            _urlRepo.Verify(r => r.GetByLongURLAsync(longUrl), Times.Once);
            _urlRepo.Verify(r => r.AddURLAsync(longUrl, It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task BuildShortUrl_ShouldCheckIfURLExists()
        {
            var service = new URLService(_urlRepo.Object);
            var url = await service.AddShortURL("www.test.com");

            _urlRepo.Verify(r => r.ExistsAsync(It.IsAny<Expression<Func<URL, bool>>>()), Times.AtLeastOnce);
        }
    }
}
//2 6 16 35 55 56