using Domain.Entities;
using Moq;
using Services.Unit.Tests.Builders;
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
        private URLServiceBuilder _serviceBuilder;

        public URLServiceTests()
        {
            _urlRepo = new FakeURLRepository();
            _serviceBuilder = new URLServiceBuilder();
        }

        [Fact]
        public async Task CreateShortURL_ShouldAddURL()
        {
            var service = _serviceBuilder
                .WithRepository(_urlRepo.Object)
                .Build();

            var longUrl = "https://www.test.com";
            var url = await service.AddShortURL(longUrl);

            _urlRepo.Verify(r => r.GetByLongURLAsync(longUrl), Times.Once);
            _urlRepo.Verify(r => r.AddURLAsync(longUrl, It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task BuildShortUrl_ShouldCheckIfURLExists()
        {
            var service = _serviceBuilder
                .WithRepository(_urlRepo.Object)
                .Build();
            var url = await service.AddShortURL("https://www.test.com");

            _urlRepo.Verify(r => r.ExistsAsync(It.IsAny<Expression<Func<URL, bool>>>()), Times.AtLeastOnce);
        }
    }
}
