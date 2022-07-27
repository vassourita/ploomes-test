using Microsoft.EntityFrameworkCore;

using PloomesTest.Core.Entities;
using PloomesTest.Core.Repositories;

namespace PloomesTest.Infrastructure.Data.Repositories
{
    public class EFClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public EFClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Client> AddAsync(Client client)
        {
            _ = await _context.Clients.AddAsync(client);
            _ = await _context.SaveChangesAsync();

            return client;
        }

        public Task<int> DeleteAsync(Client id)
        {
            _ = _context.Clients.Remove(id);

            return _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByFederalDocumentAsync(string federalDocument)
        {
            return await _context.Clients.AnyAsync(c => c.FederalDocument == federalDocument);
        }

        public Task<List<Client>> GetAllAsync()
        {
            return _context.Clients.ToListAsync();
        }

        public Task<Client> GetByIdAsync(Guid id)
        {
            return _context.Clients.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Client>> SearchByNameAsync(string nameLike)
        {
            return _context.Clients.Where(c => c.Name.ToLower().Contains(nameLike.ToLower())).ToListAsync();
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _ = _context.Clients.Update(client);

            _ = await _context.SaveChangesAsync();

            return client;
        }
    }
}