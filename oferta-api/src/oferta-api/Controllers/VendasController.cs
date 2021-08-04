using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly ILogger<VendasController> _logger;

        public VendasController(ILogger<VendasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            
        }
    }
}
