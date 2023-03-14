using LamyThematique.Infrastructure.Database.Entities.Base;
using System.Collections.Generic;

namespace LamyThematique.Infrastructure.Database.Entities.Document
{
    public class SousTheme : EntityOfInt
    {
        public string Code  { get; set; }
        
        public string Label { get; set; }

        public int ThemeId { get; set; }

        public Theme Theme { get; set; }

        public virtual ICollection<Sujet> Sujets { get; set; }
    }
}
