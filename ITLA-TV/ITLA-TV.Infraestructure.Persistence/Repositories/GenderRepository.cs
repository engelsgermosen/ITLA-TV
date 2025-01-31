using ITLA_TV.Core.Application.Interfaces.Repositories;
using ITLA_TV.Core.Domain.Entities;
using ITLA_TV.Infraestructure.Persistence.Contexts;

namespace ITLA_TV.Infraestructure.Persistence.Repositories
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        private readonly ApplicationContext context;

        public GenderRepository(ApplicationContext context) : base(context)
        {
            this.context = context;   
        }
    }
}
