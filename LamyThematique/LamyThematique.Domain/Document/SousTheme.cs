using LamyThematique.Domain.Base;

namespace LamyThematique.Domain.Document
{
    public class SousTheme : BaseValueObject
    {
        public int Id { get; set; }

        public string Code  { get; set; }
        
        public string Label { get; set; }

        public int ThemeId { get; set; }
    }
}
