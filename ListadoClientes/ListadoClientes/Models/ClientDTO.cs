using System.ComponentModel.DataAnnotations;

namespace ListadoClientes.Models;

public class ClientDTO
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string DocumentType { get; set; }

    public String DocumentNumber { get; set; }

    public DateTime? RegisterDate { get; set; }
}
