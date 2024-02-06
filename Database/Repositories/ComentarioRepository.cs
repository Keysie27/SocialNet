using SGP.Infrastructure.Persistence.Contexts;
using SGP.Core.Domain.Entities;
using SGP.Core.Application.Interfaces.Repositories;

namespace SGP.Infrastructure.Persistence.Repositories
{
    public class ComentarioRepository : GenericRepository<Comentario>, IComentarioRepository
    {
        private readonly ApplicationContext _dbContext;

        public ComentarioRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
