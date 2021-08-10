using System.Collections.Generic;
using oferta_domain.Entities;

namespace oferta_domain.Interfaces.Services
{
    public interface IServiceClientes
    {
         IEnumerable<Cliente> GetClienteByCPF(string cpf);
         IEnumerable<Cliente> GetClienteByName(string name);
    }
}