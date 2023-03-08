using System.Security.Claims;
using LamyThematique.Domain.Base;

namespace LamyThematique.Domain.User.ValueObjects
{
    public class UserAuthAppResultVO : BaseValueObject
    {
        public ClaimsIdentity ClaimsIdentity { get; set; }

        public string ResultCode { get; set; }
    }
}
