using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Threading.Tasks;
using WebApi.Requests;

namespace UrlShortner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class URLController : ControllerBase
    {
        private IURLService _service;
        public URLController(IURLService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> CreateShortURL(NewURLRequest request)
        {
            var result = await _service.AddShortURL(request.URL);
            return Ok(result);
        }
    }
}
