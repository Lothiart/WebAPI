using Repositories.Contracts;
using Business.Contracts;
using Entities;

namespace Business
{
	public class ClientBusiness : IClientBusiness
	{
		public IClientRepository _clientRepository;
		public ClientBusiness(IClientRepository ClientRepository)
		{
			_clientRepository = ClientRepository;

		}
		public async Task<List<Client>> GetClients()
		{
			return await _clientRepository.GetClients();
		}
        public async Task<List<ClientDTO>> GetClientsDTO()
        {
            return await _clientRepository.GetClientsDTO();
        }
        public async Task<bool> Create(Client client)
		{
			return await _clientRepository.Create(client);
		}
		public async Task<Client> Read(int id)
		{
			return await _clientRepository.Read(id);
		}
		public async Task<bool> Update(Client client)
		{
			return await _clientRepository.Update(client);
		}
		public async Task<bool> Delete(int id)
		{
			return await _clientRepository.Delete(id);
		}
		public async Task<List<Client>> Search(string str)
		{
			return await _clientRepository.Search(str);
		}
	}
}
