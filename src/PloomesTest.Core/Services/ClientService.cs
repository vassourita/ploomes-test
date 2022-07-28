using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;
using PloomesTest.Core.Repositories;

namespace PloomesTest.Core.Services
{
    public enum ClientCreateAction
    {
        Created,
        InvalidDocument,
        DocumentInUse
    }

    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly FederalDocumentService _federalDocumentService;

        public ClientService(
            IClientRepository clientRepository,
            FederalDocumentService federalDocumentService)
        {
            _federalDocumentService = federalDocumentService;
            _clientRepository = clientRepository;
        }

        public async Task<(ClientCreateAction, Client)> CreateAsync(CreateClientDto dto)
        {
            var isValidDocument = _federalDocumentService.Validate(dto.FederalDocument);

            if (!isValidDocument)
            {
                return (ClientCreateAction.InvalidDocument, null);
            }

            var clientExists = await _clientRepository.ExistsByFederalDocumentAsync(dto.FederalDocument);

            if (clientExists)
            {
                return (ClientCreateAction.DocumentInUse, null);
            }

            var clientType = dto.FederalDocument.Length == 11
                ? ClientType.PhysicalPerson
                : ClientType.Company;

            Client client = new(clientType, dto.FederalDocument,
                dto.Name, dto.Email, dto.Phone, dto.Address,
                dto.City, dto.State, dto.ZipCode, dto.Country);

            return (ClientCreateAction.Created, await _clientRepository.AddAsync(client));
        }

        public Task<List<Client>> SearchAsync(int page, int pageSize, string query = null)
        {
            return string.IsNullOrEmpty(query)
                ? _clientRepository.GetAllAsync(page, pageSize)
                : _clientRepository.SearchByNameAsync(query, page, pageSize);
        }
    }
}