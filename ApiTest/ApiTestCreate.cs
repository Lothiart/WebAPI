using Entities;
using Repositories.Contracts;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApiTest
{
    public class ApiTestCreateClient
    {
        private readonly IClientRepository _clientRepository;

        public ApiTestCreateClient(IClientRepository ClientRepository)
        {
            _clientRepository = ClientRepository;
        }

       
        public async Task CreateClient_ReturnsCreatedClient()
        {
            // Arrange
            var client = new Client
            {
                Name = "Jooe",
                Description = "Un clf"
            };

            // Act
            var createdClient = await _clientRepository.Create(client);

            // Assert
            Assert.NotNull(createdClient);
            Assert.Equal(client.Name, createdClient.Name);
            Assert.Equal(client.Description, createdClient.Description);
        }
    }
}
