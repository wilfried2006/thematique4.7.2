using System.Linq;
using System.Threading.Tasks;
using LamyThematique.Domain.User.Interfaces;
using LamyThematique.Domain.User.ValueObjects;
using LamyThematique.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LamyThematique.Infrastructure.Repository.Implementations
{
    internal class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ThematiqueDbContext thematiqueDbContext) : base(thematiqueDbContext)
        {

        }

        public async Task<UserAccessCodeVo> GetUserAccessCodeAsync(string email)
        {
            return await (from user in DbContext.Users
                          where user.Email == email
                          select
                          new UserAccessCodeVo()
                          {
                              Id = user.Id,
                              AccessCode = user.AccessCode
                          }).FirstOrDefaultAsync();
        }
    }
}
