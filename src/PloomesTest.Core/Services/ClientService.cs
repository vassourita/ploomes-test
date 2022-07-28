using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;
using PloomesTest.Core.Repositories;

namespace PloomesTest.Core.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> CreateAsync(CreateClientDto dto)
        {
            bool clientExists = await _clientRepository.ExistsByFederalDocumentAsync(dto.FederalDocument);

            if (clientExists)
            {
                return null;
            }

            ClientType clientType = dto.FederalDocument.Length == 11
                ? ClientType.PhysicalPerson
                : ClientType.LegalPerson;

            Client client = new(clientType, dto.FederalDocument,
                dto.Name, dto.Email, dto.Phone, dto.Address,
                dto.City, dto.State, dto.ZipCode, dto.Country);

            return await _clientRepository.AddAsync(client);
        }

        public Task<List<Client>> SearchAsync(int page, int pageSize, string query = null)
        {
            return string.IsNullOrEmpty(query)
                ? _clientRepository.GetAllAsync(page, pageSize)
                : _clientRepository.SearchByNameAsync(query, page, pageSize);
        }
    }
}