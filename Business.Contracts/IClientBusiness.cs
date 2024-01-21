using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
	public interface IClientBusiness
	{
		public Task<List<Client>> GetClients();
		public Task<List<ClientDTO>> GetClientsDTO();
        
		public Task<bool> Create(Client client);
        public Task<Client> Read(int id);
		public Task<bool> Update(Client client);
		public Task<bool> Delete(int id);
		public Task<List<Client>> Search(string name);
	}
}
