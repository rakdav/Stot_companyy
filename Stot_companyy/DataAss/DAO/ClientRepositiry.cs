using Stot_company.DataAss.Entity;
using Microsoft.EntityFrameworkCore;

namespace Stot_company.DataAss.DAO
{
    public class ClientRepositiry
    {
        
        private readonly GgContext _stotcomp;
        public ClientRepositiry(GgContext stotcomp)
        {
            _stotcomp = stotcomp;
        }
            
        public List<Client> GetAllClientonly()
        {
            return _stotcomp.Clients.ToList();
        }

        public List<Client> GetAllClientWithOrder()
        {
            return _stotcomp.Clients.Include(q => q.Orders).ToList();
        }

        public Client GetClientById(int id)
        {
            var client = _stotcomp.Clients.Include(q => q.Orders).Where(q => q.IdClient == id).FirstOrDefault();
            if (client != null) return client;
            return null!;
        }

        public async Task<Client> CreateClient(Client client)
        {
            await _stotcomp.Clients.AddAsync(client);
            await _stotcomp.SaveChangesAsync();
            return client;
        }

        public List<Client> ListPaymentClient()
        {
            return _stotcomp.Clients.Include(q => q.Payment).ToList();
        }

        public List<Client> ArrearsClient()
        {
            return _stotcomp.Clients.Include(q => q.ArrearsClient).ToList();
        }

        public async Task<Client> EditClient(Client client)
        {
            var clientToUpdate = GetClientById(client.IdClient);
            if (clientToUpdate == null) return null!;
            clientToUpdate.NameClient = client.NameClient;
            clientToUpdate.LastNameClient = client.LastNameClient;
            clientToUpdate.Email = client.Email;
            clientToUpdate.Age = client.Age;
            clientToUpdate.ArrearsClient = client.ArrearsClient;
            clientToUpdate.Passport = client.Passport;
            clientToUpdate.Sex = client.Sex;
            clientToUpdate.Payment = client.Payment;
            await _stotcomp.SaveChangesAsync();
            return clientToUpdate;
        }
        public async Task<Client> DeleteClient(int id)
        {
            var client = await _stotcomp.Clients.FindAsync(id);
            if(client == null) return null!;
            _stotcomp.Clients.Remove(client);
            await _stotcomp.SaveChangesAsync();
            return client!;
        }
    }
}
