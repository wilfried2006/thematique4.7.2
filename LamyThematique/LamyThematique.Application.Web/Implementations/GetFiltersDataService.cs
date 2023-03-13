using System.Collections.Generic;
using LamyThematique.Domain.Document.Interfaces.Services;
using System.Threading.Tasks;
using LamyThematique.Domain.Document.Interfaces.Transformers;
using LamyThematique.Domain.Enums;
using LamyThematique.Domain.User.Interfaces;
using LamyThematique.ViewModels.Web.Models.Search;
using LamyThematique.ViewModels.Web.Pages.Test;

namespace LamyThematique.Application.Web.Implementations
{
    internal class GetFiltersDataService : IGetFiltersDataService
    {
        private IDocumentRepository _documentRepository;

        public ISearchResultPageTransformer SearchResultPageTransformer { get; set; }

        public GetFiltersDataService(IDocumentRepository documentRepository, ISearchResultPageTransformer searchResultPageTransformer)
        {
            _documentRepository = documentRepository;
            SearchResultPageTransformer = searchResultPageTransformer;
        }

        public async Task<SearchResultPageViewModel> GetSearchResultPageAsync()
        {
            var sujets = await _documentRepository.GetSujetsItemsAsync();
            var themes = await _documentRepository.GetThemesItemsAsync();
            var sousThemes = await _documentRepository.GetSousThemesItemsAsync();

            return SearchResultPageTransformer.Tranform(sujets, themes, sousThemes, PageEnum.EnImage);
        }
    }
}
