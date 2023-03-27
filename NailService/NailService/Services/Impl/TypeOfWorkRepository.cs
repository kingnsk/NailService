using NailService.Data;

namespace NailService.Services.Impl
{
    public class TypeOfWorkRepository : ITypeOfWorkRepository
    {

        #region Services
        private readonly NailSeviceDbContext _dbContext;
        private readonly ILogger<TypeOfWorkRepository> _logger;
        #endregion

        #region Constructors
        public TypeOfWorkRepository(NailSeviceDbContext dbContext, ILogger<TypeOfWorkRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public int Add(TypeOfWork item)
        {
            _dbContext.TypeOfWorks.Add(item);
            _dbContext.SaveChanges();
            return item.WorkId;
        }

        public void Delete(TypeOfWork item)
        {
            if (item == null)
                throw new NullReferenceException();
            Delete(item.WorkId);
        }

        public void Delete(int id)
        {
            var work = GetById(id);
            if (work == null)
                throw new KeyNotFoundException();
            _dbContext.Remove(work);
            _dbContext.SaveChanges();
        }

        public IList<TypeOfWork> GetAll()
        {
            return _dbContext.TypeOfWorks.ToList();
        }

        public TypeOfWork? GetById(int id)
        {
            return _dbContext.TypeOfWorks.FirstOrDefault(work => work.WorkId == id);
        }

        public void Update(TypeOfWork item)
        {
            if (item == null)
                throw new NullReferenceException();
            var work = GetById(item.WorkId);
            if (work == null)
                throw new KeyNotFoundException();
            work.TypeOfService = item.TypeOfService;
            work.Client = item.Client;

            _dbContext.Update(work);
            _dbContext.SaveChanges();
        }
    }
}
