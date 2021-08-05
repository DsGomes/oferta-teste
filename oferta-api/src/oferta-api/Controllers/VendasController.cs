using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain;
using oferta_domain.Interfaces;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly ILogger<VendasController> _logger;
        private readonly IRepositoryVendas _vendas;

        public VendasController(ILogger<VendasController> logger,
                                    IRepositoryVendas vendas)
        {
            _logger = logger;
            _vendas = vendas;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public ActionResult<IEnumerable<Venda>> GetAll()
        {
            return Ok(_vendas.GetAll());
        }

        [HttpGet]
        [Route("buscar-por-cliente")]
        public ActionResult<IEnumerable<Venda>> GetByCliente(int clienteId)
        {
            return Ok(_vendas.GetById(clienteId));
        }
    }
}
