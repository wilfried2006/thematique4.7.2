using LamyThematique.Infrastructure.Database.Entities.Base;
using System.Collections.Generic;

namespace LamyThematique.Infrastructure.Database.Entities.Document
{
    public class Theme : EntityOfInt
    {
        public string Code { get; set; }

        public string Label { get; set; }

        public virtual ICollection<SousTheme> SousThemes { get; set; }
    }
}
