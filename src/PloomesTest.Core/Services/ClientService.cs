using AutoMapper;
using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;
using PloomesTest.Core.Repositories;

namespace PloomesTest.Core.Services
{
    public enum ClientAction
    {
        Ok,
        InvalidDocument,
        DocumentInUse,
        NotFound
    }

    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly FederalDocumentService _federalDocumentService;

        public ClientService(
            IClientRepository clientRepository,
            FederalDocumentService federalDocumentService,
            IMapper mapper)
        {
            _mapper = mapper;
            _federalDocumentService = federalDocumentService;
            _clientRepository = clientRepository;
        }

        public async Task<(ClientAction, Client)> CreateAsync(CreateClientDto dto)
        {
            var isValidDocument = _federalDocumentService.Validate(dto.FederalDocument);

            if (!isValidDocument)
            {
                return (ClientAction.InvalidDocument, null);
            }

            var clientExists = await _clientRepository.ExistsByFederalDocumentAsync(dto.FederalDocument);

            if (clientExists)
            {
                return (ClientAction.DocumentInUse, null);
            }

            var clientType = dto.FederalDocument.Length == 11
                ? ClientType.PhysicalPerson
                : ClientType.Company;

            var client = new Client(clientType, dto.FederalDocument,
                dto.Name, dto.Email, dto.Phone, dto.Address,
                dto.City, dto.State, dto.ZipCode, dto.Country);

            return (ClientAction.Ok, await _clientRepository.AddAsync(client));
        }

        public async Task<(bool, List<Client>)> SearchAsync(int page, int pageSize, string type = null, string query = null)
        {
            ClientType? clientType = type switch
            {
                "person" => ClientType.PhysicalPerson,
                "company" => ClientType.Company,
                _ => null
            };

            return string.IsNullOrEmpty(query)
                ? (true, await _clientRepository.GetAllAsync(page, pageSize, clientType))
                : (true, await _clientRepository.SearchByNameAsync(query, page, pageSize, clientType));
        }

        public async Task<(ClientAction, Client)> UpdateAsync(Guid id, UpdateClientDto dto)
        {
            var isValidDocument = _federalDocumentService.Validate(dto.FederalDocument);

            if (!isValidDocument)
            {
                return (ClientAction.InvalidDocument, null);
            }

            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
            {
                return (ClientAction.NotFound, null);
            }

            if (client.FederalDocument != dto.FederalDocument &&
                await _clientRepository.ExistsByFederalDocumentAsync(dto.FederalDocument))
            {
                return (ClientAction.DocumentInUse, null);
            }

            client = _mapper.Map(dto, client);

            return (ClientAction.Ok, await _clientRepository.UpdateAsync(client));
        }
    }
}