namespace oferta_domain.Interfaces
{
    public interface IRepositoryClientes : IRepositoryBase<Cliente>
    {
         Cliente getByName(string name);
         Cliente getByCPF(byte[] cpf);
    }
}