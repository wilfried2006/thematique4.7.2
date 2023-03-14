using System.Threading.Tasks;
using LamyThematique.Domain.User.ValueObjects;

namespace LamyThematique.Domain.User.Interfaces
{
    public interface IUserRepository
    {
        Task<UserAccessCodeVo> GetUserAccessCodeAsync(string email);
    }
}
