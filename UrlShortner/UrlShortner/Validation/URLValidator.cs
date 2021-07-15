using FluentValidation;
using System;
using WebApi.Requests;

namespace WebApi.Validation
{
    public class URLValidator : AbstractValidator<NewURLRequest>
    {
        public URLValidator()
        {
            RuleFor(x => x.URL).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _));
        }
    }
}
