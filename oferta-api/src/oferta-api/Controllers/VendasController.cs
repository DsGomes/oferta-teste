using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain.Entities;
using oferta_domain.Interfaces;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Sistema")]
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

        [HttpPost]
        [Route("cadastrar-venda")]
        public ActionResult Post([FromBody]Venda venda){
            _vendas.Add(venda);
            return Created("/api/vendas/cadastrar-venda", venda);
        }
    }
}
