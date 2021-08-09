using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Sistema")]
    public class EnderecosController : ControllerBase
    {
        private readonly ILogger<EnderecosController> _logger;
        private readonly IRepositoryEnderecos _enderecoRepository;

        public EnderecosController(ILogger<EnderecosController> logger,
                                    IRepositoryEnderecos endereco)
        {
            _logger = logger;
            _enderecoRepository = endereco;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public ActionResult<IEnumerable<Endereco>> GetAll()
        {
            return Ok(_enderecoRepository.GetAll());
        }

        [HttpGet]
        [Route("buscar-por-cliente")]
        public ActionResult<IEnumerable<Endereco>> GetByCliente(int clienteId)
        {
            return Ok(_enderecoRepository.GetById(clienteId));
        }

        [HttpPost]
        [Route("cadastrar-endereco")]
        public ActionResult Post([FromBody]Endereco endereco){
            _enderecoRepository.Add(endereco);
            return StatusCode(201);
        }
    }
}
