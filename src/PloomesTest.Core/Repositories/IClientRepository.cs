using PloomesTest.Core.Entities;

namespace PloomesTest.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<List<Client>> GetAllAsync();
        Task<List<Client>> SearchByNameAsync(string nameLike);
        Task<Client> AddAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<int> DeleteAsync(Client id);
        Task<bool> ExistsByFederalDocumentAsync(string federalDocument);
    }
}