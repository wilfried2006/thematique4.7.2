using System.Collections.Generic;
using LamyThematique.Domain.Enums;
using LamyThematique.ViewModels.Web.Pages.Test;

namespace LamyThematique.Domain.Document.Interfaces.Transformers
{
    public interface ISearchResultPageTransformer
    {
        SearchResultPageViewModel Tranform(List<Sujet> sujets, List<Theme> themes, List<SousTheme> sousThemes, PageEnum page);
    }
}
