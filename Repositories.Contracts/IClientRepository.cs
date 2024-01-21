
using Entities;

namespace Repositories.Contracts
{
	public interface IClientRepository
	{
		Task<List<Client>> GetClients();
		Task<List<ClientDTO>> GetClientsDTO();
		Task<bool> Create(Client client);
		Task<Client> Read(int id);
		Task<bool> Update(Client client);
		Task<bool> Delete(int id);
		Task<List<Client>> Search(string str);
	}
}
