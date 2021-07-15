using Domain.Interfaces;
using Services.Unit.Tests.Fakes;

namespace Services.Unit.Tests.Builders
{
    public class URLServiceBuilder
    {
        private IURLRepository _repo;
        public URLServiceBuilder()
        {
            _repo = new FakeURLRepository().Object;
        }

        public URLServiceBuilder WithRepository(IURLRepository repo)
        {
            _repo = repo;
            return this;
        }

        public URLService Build()
        {
            return new URLService(_repo);
        }
    }
}
