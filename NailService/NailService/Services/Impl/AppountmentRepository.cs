using Microsoft.EntityFrameworkCore;
using NailService.Data;

namespace NailService.Services.Impl
{
    public class AppountmentRepository : IAppountmentRepository
    {

        #region Services
        private readonly NailSeviceDbContext _dbContext;
        private readonly ILogger<AppountmentRepository> _logger;
        #endregion

        #region Constructors
        public AppountmentRepository(NailSeviceDbContext dbContext, ILogger<AppountmentRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public int Add(Appountment item)
        {
            _dbContext.Appountments.Add(item);
            _dbContext.SaveChanges();
            return item.AppountmentId;
        }

        public void Delete(Appountment item)
        {
            if (item == null)
                throw new NullReferenceException();
            Delete(item.AppountmentId);
        }

        public void Delete(int id)
        {
            var appountment = GetById(id);
            if (appountment == null)
                throw new KeyNotFoundException();
            _dbContext.Remove(appountment);
            _dbContext.SaveChanges();
        }

        public IList<Appountment> GetAll()
        {
            var appountments = _dbContext.Appountments.Include(w => w.TypeOfWork).Include(c=>c.Client);

            //return _dbContext.Appountments.ToList();
            return appountments.ToList();
        }

        public Appountment? GetById(int id)
        {
            return _dbContext.Appountments.FirstOrDefault(appountment => appountment.AppountmentId == id);
        }

        public void Update(Appountment item)
        {
            if (item == null)
                throw new NullReferenceException();
            var appountment = GetById(item.AppountmentId);
            if (appountment == null)
                throw new KeyNotFoundException();
            appountment.DateOfReceipt = item.DateOfReceipt;
            appountment.TimeOfReceipt = item.TimeOfReceipt;
            appountment.Comment = item.Comment;
            appountment.CreatedAt= item.CreatedAt;

            _dbContext.Update(appountment);
            _dbContext.SaveChanges();
        }
    }
}
