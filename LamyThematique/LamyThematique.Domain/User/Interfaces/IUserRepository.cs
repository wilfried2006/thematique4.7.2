using System.Threading.Tasks;
using LamyThematique.Domain.User.ValueObjects;

namespace LamyThematique.Domain.User.Interfaces
{
    public interface IUserRepository
    {
        Task<UserAccessCodeVO> GetUserAccessCodeAsync(string email);
    }
}
