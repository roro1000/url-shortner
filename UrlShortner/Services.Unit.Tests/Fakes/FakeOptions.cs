using Microsoft.Extensions.Options;
using Moq;

namespace Services.Unit.Tests.Fakes
{
    public class FakeOptions<TOptions> : Mock<IOptions<TOptions>>
        where TOptions : class
    {
        private TOptions _options;
        public FakeOptions<TOptions> WithOptions(TOptions options)
        {
            _options = options;
            return this;
        }

        public override IOptions<TOptions> Object
        {
            get
            {
                SetupGet(o => o.Value).Returns(_options);
                return base.Object;
            }
        }
    }
}
