using PloomesTest.Core.Entities;

namespace PloomesTest.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task<IEnumerable<Client>> SearchByNameAsync(string nameLike);
        Task<Client> AddAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<int> DeleteAsync(Guid id);
        Task<bool> ExistsByFederalDocumentAsync(string federalDocument);
    }
}