using oferta_domain.Entities;

namespace oferta_domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
         Usuario BuscarUsuarioPorEmail(string email);
    }
}