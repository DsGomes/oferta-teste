using System.Collections.Generic;
using oferta_domain.Entities;

namespace oferta_domain.Interfaces.Repositories
{
    public interface IRepositoryStatus
    {
         IEnumerable<StatusCliente> GetStatusCliente();
    }
}