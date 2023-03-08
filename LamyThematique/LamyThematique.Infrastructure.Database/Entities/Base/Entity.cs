using System;
using System.ComponentModel.DataAnnotations;

namespace LamyThematique.Infrastructure.Database.Entities.Base
{
    public abstract class Entity<TKey> : IHasKey<TKey>
    {
        [Required]
        public TKey Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
