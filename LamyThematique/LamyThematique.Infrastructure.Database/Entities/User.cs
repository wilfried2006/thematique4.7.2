using LamyThematique.Infrastructure.Database.Entities.Base;

namespace LamyThematique.Infrastructure.Database.Entities
{ 
    public class User : EntityOfInt
    { 
        public string FirstName { get; set; }
         
        public string LastName { get; set; }
         
        public string AccessCode { get; set; }
         
        public string Email { get; set; }
    }
}
