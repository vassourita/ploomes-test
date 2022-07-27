using Microsoft.AspNetCore.Mvc;
using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;
using PloomesTest.Core.Repositories;
using PloomesTest.Core.Services;

namespace PloomesTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        private readonly IClientRepository _clientRepository;

        public ClientController(
            ClientService clientService,
            IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] CreateClientDto dto)
        {
            Client client = await _clientService.CreateAsync(dto);

            return client == null
                ? BadRequest()
                : Created(Url.Link("GetClientById", new { id = client.Id }), client);
        }

        [HttpGet]
        [Route("{id}", Name = "GetClientById")]
        public async Task<IActionResult> Show(Guid id)
        {
            Client client = await _clientRepository.GetByIdAsync(id);

            return client == null ? NotFound() : Ok(client);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Client> clients = await _clientRepository.GetAllAsync();

            return Ok(clients);
        }
    }
}