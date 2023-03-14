using LamyThematique.Infrastructure.Database.Entities.Base;

namespace LamyThematique.Infrastructure.Database.Entities.Document
{
    public class Sujet : EntityOfInt
    {
        public string Code { get; set; }

        public string Label { get; set; }

        public int SousThemeId { get; set; }

        public SousTheme SousTheme { get; set; }
    }
}
