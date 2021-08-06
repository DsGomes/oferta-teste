using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain;
using oferta_domain.Interfaces;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IRepositoryClientes _clientes;

        public ClientesController(ILogger<ClientesController> logger, 
                                    IRepositoryClientes clientes)
        {
            _logger = logger;
            _clientes = clientes;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public ActionResult<IEnumerable<Cliente>> GetAll()
        {
            return Ok(_clientes.GetAll());
        }
        
        [HttpGet]
        [Route("buscar-por-nome")]
        public ActionResult<Cliente> GetByName(string name)
        {
            return Ok(_clientes.getByName(name));
        }

        [HttpGet]
        [Route("buscar-por-cpf")]
        public ActionResult<Cliente> GetByCpf(byte[] cpf)
        {
            return Ok(_clientes.getByCPF(cpf));
        }

        [HttpPost]
        [Route("inserir")]
        public ActionResult Post(Cliente cliente){
            _clientes.Add(cliente);
            return Created("/api/clientes/inserir", cliente);
        }

        [HttpPut]
        [Route("atualizar")]
        public ActionResult Put(Cliente cliente){
            _clientes.Update(cliente);
            return Created("/api/clientes/atualizar", cliente);
        }

        [HttpDelete]
        [Route("excluir")]
        public ActionResult Delete(Cliente cliente){
            _clientes.Remove(cliente);
            return Ok();
        }
    }
}
