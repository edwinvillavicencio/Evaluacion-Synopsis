using ListadoClientes.Models;
using ListadoClientes.DAO.Entities;

namespace ListadoClientes.Converters;

public static class ClientExtensions
{
    public static ClientDTO ToDto(this Client entity)
    {
        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            DocumentType = entity.DocumentType,
            DocumentNumber = entity.DocumentNumber,
            Email = entity.Email,
            RegisterDate = entity.RegisterDate
        };
    }
}
