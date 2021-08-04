using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(ILogger<ProdutosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {

        }
    }
}
