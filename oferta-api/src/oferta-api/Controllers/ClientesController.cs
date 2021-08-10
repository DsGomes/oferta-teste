using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;
using oferta_domain.Interfaces.Services;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Sistema")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IRepositoryClientes _clientes;
        private readonly IRepositoryStatus _status;
        private readonly IServiceClientes _clienteService;

        public ClientesController(ILogger<ClientesController> logger,
                                    IRepositoryClientes clientes,
                                    IRepositoryStatus status,
                                    IServiceClientes clienteService)
        {
            _logger = logger;
            _clientes = clientes;
            _status = status;
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("buscar-status")]
        public ActionResult<IEnumerable<StatusCliente>> GetStatus()
        {
            return Ok(_status.GetAll());
        }

        [HttpGet]
        [Route("buscar-todos")]
        public ActionResult<IEnumerable<Cliente>> GetAll()
        {
            return Ok(_clientes.GetAll());
        }

        [HttpGet]
        [Route("buscar-por-nome")]
        public ActionResult<IEnumerable<Cliente>> GetByName(string name)
        {
            return Ok(_clienteService.GetClienteByName(name));
        }

        [HttpGet]
        [Route("buscar-por-cpf")]
        public ActionResult<Cliente> GetByCpf(string cpf)
        {
            return Ok(_clientes.getByCPF(cpf));
        }

        [HttpPost]
        [Route("inserir")]
        public ActionResult Post([FromBody]Cliente cliente){
            _clientes.Add(cliente);
            return Created("/api/clientes/inserir", cliente);
        }

        [HttpPut]
        [Route("atualizar")]
        public ActionResult Put([FromBody]Cliente cliente){
            _clientes.Update(cliente);
            return Created("/api/clientes/atualizar", cliente);
        }

        [HttpDelete]
        [Route("excluir")]
        public ActionResult Delete([FromBody]Cliente cliente){
            _clientes.Remove(cliente);
            return Ok();
        }
    }
}
