using SGP.Infrastructure.Persistence.Contexts;
using SGP.Core.Domain.Entities;
using SGP.Core.Application.Interfaces.Repositories;

namespace SGP.Infrastructure.Persistence.Repositories
{
    public class PublicacionRepository : GenericRepository<Publicacion>, IPublicacionRepository
    {
        private readonly ApplicationContext _dbContext;

        public PublicacionRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
