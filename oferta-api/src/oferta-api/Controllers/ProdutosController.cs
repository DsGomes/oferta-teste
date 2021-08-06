using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain;
using oferta_domain.Interfaces;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IRepositoryProdutos _produtos;
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(IRepositoryProdutos produtos,
                                    ILogger<ProdutosController> logger)
        {
            _produtos = produtos;
            _logger = logger;
        }

        [HttpGet]
        [Route("buscar-todos")]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            return Ok(_produtos.GetAll());
        }

        [HttpGet]
        [Route("buscar-por-id")]
        public ActionResult<Produto> GetById(int id)
        {
            return Ok(_produtos.GetById(id));
        }

        [HttpPost]
        [Route("inserir")]
        public ActionResult Post(Produto produto)
        {
            _produtos.Add(produto);
            return Created("/api/produtos/inserir", produto);
        }

        [HttpPut]
        [Route("atualizar")]
        public ActionResult Put(Produto produto)
        {
            _produtos.Update(produto);
            return Created("/api/produtos/atualizar", produto);
        }

        [HttpDelete]
        [Route("excluir")]
        public ActionResult Delete(Produto produto)
        {
            _produtos.Remove(produto);
            return Ok();
        }
    }
}
