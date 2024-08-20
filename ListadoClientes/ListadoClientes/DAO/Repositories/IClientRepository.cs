using ListadoClientes.DAO.Entities;
using ListadoClientes.DAO.Util;

namespace ListadoClientes.DAO.Repositories;
public interface IClientRepository
{
    Task<List<Client>> GetAll();

    Task<Client?> Get(int id);

}

