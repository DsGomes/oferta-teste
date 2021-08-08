using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using oferta_api.Helpers;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IConfiguration _configuration;

        public AuthController(IRepositoryUsuario repositoryUsuario,
                                IConfiguration configuration)
        {
            this._repositoryUsuario = repositoryUsuario;
            this._configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("autenticar")]
        public IActionResult Autenticar([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioExistente = _repositoryUsuario.BuscarUsuarioPorEmail(usuario.email);

                if (usuarioExistente == null)
                    return NotFound("Email inválido");

                var token = JwtAuth.GenerateToken(usuarioExistente, _configuration);

                return Ok(new
                {
                    Token = token,
                    Usuario = usuarioExistente
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex + "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }
}