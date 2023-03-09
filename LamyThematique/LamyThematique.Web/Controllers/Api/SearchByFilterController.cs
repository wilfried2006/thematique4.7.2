using System;
using System.Collections.Generic;
using System.Web.Http;
using LamyThematique.ViewModels.Web.Models.Search;
using LamyThematique.ViewModels.Web.Pages.Shared.Search;

namespace LamyThematique.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class SearchByFilterController : ApiController
    {
        public SearchByFilterController()
        { }

        [HttpPost]
        public List<SearchContentResultItem> Index(SearchFilterViewModel searchFilterViewModel)
        {
            var model = new List<SearchContentResultItem>
            {
                new SearchContentResultItem()
                {
                    Id = 1,
                    Badge = "FICHE PRATIQUE",
                    Title = "Lutter contre la corruptio",
                    Subject = "Prévenir et détecter la corruption",
                    CreatedAt = DateTime.Now.ToString("dd/MM/YYYY")
                },
                  new SearchContentResultItem()
                {
                    Id = 2,
                    Badge = "FICHE PRATIQUE",
                    Title = "Lutter contre la CORRUPTIO",
                    Subject = "Prévenir et détecter la corruption",
                    CreatedAt = DateTime.Now.AddDays(23).ToString("dd/MM/YYYY")
                }
            };

            return model;
        }
    }
}