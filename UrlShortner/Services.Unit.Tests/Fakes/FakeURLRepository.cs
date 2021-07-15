using Common.Models;
using Domain.Interfaces;
using Moq;

namespace Services.Unit.Tests.Fakes
{
    public class FakeURLRepository : Mock<IURLRepository>
    {
        private URLDetails _url = null;
        public FakeURLRepository()
        {
            Setup(r => r.AddURLAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new URLDetails());
        }

        public FakeURLRepository WithURLExists(URLDetails url)
        {
            _url = url;
            return this;
        }

        public override IURLRepository Object
        {
            get
            {
                Setup(r => r.GetByLongURLAsync(It.IsAny<string>())).ReturnsAsync(_url);
                return base.Object;
            }
        }
    }
}
