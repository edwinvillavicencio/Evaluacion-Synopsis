using ListadoClientes.Converters;
using ListadoClientes.Models;
using ListadoClientes.DAO.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ListadoClientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClientRepository _clientRepository;

        public ClientesController(ILogger<ClientesController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        [HttpGet(Name = "GetClientList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _clientRepository.GetAll();

            var dtos = entities.Select(d => d.ToDto()).ToList();

            return Ok(dtos);
        }
    }
}
