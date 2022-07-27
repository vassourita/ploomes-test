using Microsoft.AspNetCore.Mvc;

using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;
using PloomesTest.Core.Repositories;
using PloomesTest.Core.Services;

namespace PloomesTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/clients")]
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

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="dto">The payload to create the client.</param>
        /// <returns>A 201 response with the created client or a 400 response with the request errors.</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Store([FromBody] CreateClientDto dto)
        {
            Client client = await _clientService.CreateAsync(dto);

            return client == null
                ? BadRequest()
                : Created(Url.Link("GetClientById", new { id = client.Id }), client);
        }

        /// <summary>
        /// Gets the client with the given id.
        /// </summary>
        /// <param name="id">The client id.</param>
        /// <returns>A 200 response with the found client or a 404 empty response if it was not found.</returns>
        [HttpGet]
        [Route("{id}", Name = "GetClientById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Show([FromRoute] Guid id)
        {
            Client client = await _clientRepository.GetByIdAsync(id);

            return client == null ? NotFound() : Ok(client);
        }

        /// <summary>
        /// Gets all categories within the given page, page size and query.
        /// </summary>
        /// <param name="search">The search options.</param>
        /// <returns>A 200 response with the found categories.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Client>))]
        public async Task<IActionResult> Index([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string query)
        {
            IEnumerable<Client> clients = await _clientService.SearchAsync(page, pageSize, query);

            return Ok(clients);
        }
    }
}