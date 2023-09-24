using Microsoft.EntityFrameworkCore;
using NailService.Data;
using System.Security.Cryptography;

namespace NailService.Services.Impl
{
    public class ClientRepository : IClientRepository
    {
        #region Services

        private readonly NailSeviceDbContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        #endregion

        #region Constructors

        public ClientRepository(NailSeviceDbContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #endregion

        public int Add(Client item)
        {
            _dbContext.Clients.Add(item);
            _dbContext.SaveChanges();
            return item.ClientId;
        }

        public void Delete(Client item)
        {
            if (item == null)
                throw new NullReferenceException();
            Delete(item.ClientId);
        }

        public void Delete(int id)
        {
            var client = GetById(id);
            if (client == null)
                throw new KeyNotFoundException();
            _dbContext.Remove(client);
            _dbContext.SaveChanges();
        }

        public Client? GetById(int id) 
        {
            var response = _dbContext.Clients.FirstOrDefault(client => client.ClientId == id);
            return response;
        }

        public IList<Client> GetAll()
        {
            return _dbContext.Clients.ToList();
            //var clients = _dbContext.Clients.Include(p => p.Appountments);
            //return clients.ToList();
        }

        public void Update(Client item)
        {
            if (item == null)
                throw new NullReferenceException();
            var client = GetById(item.ClientId);
            if (client == null)
                throw new KeyNotFoundException();
            client.Phone = item.Phone;
            client.LastName = item.LastName;
            client.FirstName = item.FirstName;
            client.Patronymic = item.Patronymic;
            client.Comment = item.Comment;

            _dbContext.Update(client);
            _dbContext.SaveChanges();
        }
    }
}
