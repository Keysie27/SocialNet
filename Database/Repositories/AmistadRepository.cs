using SGP.Infrastructure.Persistence.Contexts;
using SGP.Core.Domain.Entities;
using SGP.Core.Application.Interfaces.Repositories;

namespace SGP.Infrastructure.Persistence.Repositories
{
    public class AmistadRepository : GenericRepository<Amistad>, IAmistadRepository
    {
        private readonly ApplicationContext _dbContext;

        public AmistadRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
