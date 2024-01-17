using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repositories
{
	public class ClientRepository : IClientRepository
	{
		private Context _context;
		public ClientRepository(Context context)
		{
			_context = context;
		}
		public async Task<List<Client>> GetClients()
		{
			return await _context.Clients.ToListAsync();
		}
		public async Task<bool> Create(Client client)
		{
			try
			{
				_context.Clients.Add(client);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public async Task<Client> Read(int id)
		{
			Client client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
			
			client.Articles = await _context.Articles.Where(c =>c.ClientId == id).ToListAsync();
			return client;
		}
		public async Task<bool> Update(Client client)
		{
			try
			{
				var clientToEdit = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
				clientToEdit.Name = client.Name;
				clientToEdit.Description = client.Description;
				
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public async Task<bool> Delete(int id)
		{
			try
			{
				_context.Clients.Remove(await _context.Clients.FirstOrDefaultAsync(c => c.Id == id));
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public async Task<List<Client>> Search(string str)
		{
			return await _context.Clients.Where(c => (c.Id.ToString()).Contains(str) || c.Name.Contains(str) || c.Description.Contains(str)).ToListAsync();
		}

	}
}
