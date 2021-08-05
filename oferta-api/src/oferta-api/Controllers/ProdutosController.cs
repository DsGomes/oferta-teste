using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oferta_domain;
using oferta_domain.Interfaces;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public void Post(Produto produto)
        {
            _produtos.Add(produto);
        }

        [HttpPut]
        [Route("atualizar")]
        public void Put(Produto produto)
        {
            _produtos.Update(produto);
        }

        [HttpDelete]
        [Route("excluir")]
        public void Delete(Produto produto)
        {
            _produtos.Remove(produto);
        }
    }
}
