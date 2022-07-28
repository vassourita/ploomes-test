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
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage))
                });
            }

            var (status, client) = await _clientService.CreateAsync(dto);

            return status switch
            {
                ClientAction.Ok => Created(Url.Link("GetClientById", new { id = client.Id }), client),
                ClientAction.InvalidDocument => BadRequest(new
                {
                    Errors = new[] { "Invalid federal document. Try a valid CPF or CNPJ, without punctuation" }
                }),
                ClientAction.DocumentInUse => BadRequest(new
                {
                    Errors = new[] { "A client with this federal document already exists" }
                }),
                ClientAction.NotFound => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
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
            var client = await _clientRepository.GetByIdAsync(id);

            return client == null ? NotFound() : Ok(client);
        }

        /// <summary>
        /// Gets all clients within the given page, page size, query and client type.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="query">The company name to be searched.</param>
        /// <param name="type">The company type to be filtered. Must be 'person' or 'company', oyherwise it will be ignored;</param>
        /// <returns>A 200 response with the found clients.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Client>))]
        public async Task<IActionResult> Index(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string query = null,
            [FromQuery] string type = null)
        {
            if (type != null)
            {
                type = type.ToLower() switch
                {
                    "person" => ClientType.PhysicalPerson.ToString(),
                    "company" => ClientType.Company.ToString(),
                    _ => null,
                };
            }

            var clients = await _clientService.SearchAsync(
                page, pageSize, type, query);

            return Ok(clients);
        }

        /// <summary>
        /// Deletes the client with the given id.
        /// </summary>
        /// <param name="id">The id of the client to be deleted.</param>
        /// <returns>A 204 response or a 404 empty response if it was not found.</returns>
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Destroy([FromRoute] Guid id)
        {
            var deleted = await _clientRepository.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }

        /// <summary>
        /// Updates a client.
        /// </summary>
        /// <param name="id">The id of the client to be updated.</param>
        /// <param name="dto">The payload to update the client.</param>
        /// <returns>A 200 response with the updated client or a 400 response with the request errors.</returns>
        [HttpPut]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateClientDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage))
                });
            }

            var (status, client) = await _clientService.UpdateAsync(id, dto);

            return status switch
            {
                ClientAction.Ok => Ok(client),
                ClientAction.InvalidDocument => BadRequest(new
                {
                    Errors = new[] { "Invalid federal document. Try a valid CPF or CNPJ, without punctuation" }
                }),
                ClientAction.DocumentInUse => BadRequest(new
                {
                    Errors = new[] { "A client with this federal document already exists" }
                }),
                ClientAction.NotFound => NotFound(),
                _ => throw new NotImplementedException()
            };
        }
    }
}