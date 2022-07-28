using PloomesTest.Core.Entities;

namespace PloomesTest.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<List<Client>> GetAllAsync(int page, int pageSize);
        Task<List<Client>> SearchByNameAsync(string nameLike, int page, int pageSize);
        Task<Client> AddAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsByFederalDocumentAsync(string federalDocument);
    }
}