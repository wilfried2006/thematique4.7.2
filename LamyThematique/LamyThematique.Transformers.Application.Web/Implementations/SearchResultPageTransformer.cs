using LamyThematique.Domain.Document.Interfaces.Transformers;
using System.Collections.Generic;
using System.Linq;
using LamyThematique.Domain.Document;
using LamyThematique.ViewModels.Web.Models;
using LamyThematique.ViewModels.Web.Pages.Test;
using LamyThematique.Domain.Enums;
using LamyThematique.ViewModels.Web.Models.Search;

namespace LamyThematique.Transformers.Application.Web.Implementations
{
    internal class SearchResultPageTransformer : ISearchResultPageTransformer
    {
        public SearchResultPageViewModel Tranform(List<Sujet> sujets, List<Theme> themes, List<SousTheme> sousThemes, PageEnum page)
        {
            var sujetsList = new SelectListViewModel()
            {
                Id = 1,
                Title = "Sur le sujet",
                Items = sujets.Select(x => new SelectListItemViewModel()
                {
                    Id = x.Id,
                    Label = x.Label,
                    ParentId = x.SousThemeId,
                    Selected = false
                })
            };

            var themesList = new SelectListViewModel()
            {
                Id = 2,
                Title = "Je recherche des contenus sur",
                Items = themes.Select(x => new SelectListItemViewModel()
                {
                    Id = x.Id,
                    Label = x.Label,
                    Selected = false
                })
            };

            var sousThemesList = new SelectListViewModel()
            {
                Id = 3,
                Title = "Et plus precisement",
                Items = sousThemes.Select(x => new SelectListItemViewModel()
                {
                    Id = x.Id,
                    Label = x.Label,
                    ParentId = x.ThemeId,
                    Selected = false
                })
            };

            return new SearchResultPageViewModel()
            {
                SelectFilters = new List<SelectListViewModel>() { themesList, sousThemesList, sujetsList },
                //Types = 
                EnableTypes = page == PageEnum.EnImage,
                SelectedItems = { },
                Types = GetCheckBoxChoices(page),
                Resultat = new List<SearchContentResultItem>()
            };
        }


        private List<CheckboxItemViewModel> GetCheckBoxChoices(PageEnum page)
        {
            return page == PageEnum.EnImage
                ? new List<CheckboxItemViewModel>()
                {
                    new CheckboxItemViewModel()
                    {
                        Id = 1,
                        Label = "Infographies",
                        Selected = false
                    },
                    new CheckboxItemViewModel()
                    {
                        Id = 2,
                        Label = "Arbres décisionnels",
                        Selected = false
                    },
                    new CheckboxItemViewModel()
                    {
                        Id = 3,
                        Label = "Checklists",
                        Selected = false
                    },
                }
                : new List<CheckboxItemViewModel>();
        }
    }
}
