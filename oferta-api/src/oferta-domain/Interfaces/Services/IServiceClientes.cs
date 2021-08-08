using System.Collections.Generic;
using oferta_domain.Entities;

namespace oferta_domain.Interfaces
{
    public interface IServiceClientes
    {
         Cliente GetClienteByCPF(long cpf);
         IEnumerable<Cliente> GetClienteByName(string name);
    }
}