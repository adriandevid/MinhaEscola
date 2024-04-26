using Microsoft.EntityFrameworkCore;
using MinhaEscola.Service.Domain.Academic.Class.Interfaces;
using MinhaEscola.Service.Domain.Academic.Class.Limits;
using MinhaEscola.Service.Infrastructure.Data.Context;
using MinhaEscola.Service.Infrastructure.Data.Repositories.Base;

namespace MinhaEscola.Service.Infrastructure.Data.Repositories
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(ApplicationContext context) : base(context) { }

        public async Task<List<Class>> GetClassesOfSchoolByUserReference(string userReference)
            => await _dbSet.Include(x => x.School).ThenInclude(x => x.UsersSchool).Where(x => x.School.UsersSchool.Any(userSchool => userSchool.UserId == userReference)).ToListAsync();
    }
}
