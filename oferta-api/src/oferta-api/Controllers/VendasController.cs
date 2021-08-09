using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain.Entities;
using oferta_domain.Interfaces;
using oferta_domain.Interfaces.Services;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Sistema")]
    public class VendasController : ControllerBase
    {
        private readonly ILogger<VendasController> _logger;
        private readonly IserviceVendas _vendaService;
        private readonly IRepositoryVendas _vendas;

        public VendasController(ILogger<VendasController> logger,
                                    IserviceVendas vendaService,
                                    IRepositoryVendas vendas)
        {
            _logger = logger;
            _vendaService = vendaService;
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
        public ActionResult Post(int id_cliente, [FromBody]int[] produtos){
            _vendaService.CadastrarVenda(id_cliente, produtos);
            return StatusCode(201);
        }
    }
}
