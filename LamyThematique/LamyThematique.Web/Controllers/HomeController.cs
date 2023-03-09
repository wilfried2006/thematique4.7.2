using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using LamyThematique.Domain;
using LamyThematique.Domain.Helpers;
using LamyThematique.Domain.User.Interfaces.Services;
using LamyThematique.ViewModels.Web.Models.Search;
using LamyThematique.ViewModels.Web.Pages.Home;
using LamyThematique.ViewModels.Web.Pages.Test;
using LamyThematique.Web.Models;
using Microsoft.Extensions.Logging;
using Schema.NET;

namespace LamyThematique.Web.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        //private readonly IAppLogger<HomeController> _logger;

        private readonly IGetUserPageService _getUserPageService;

        public HomeController(IGetUserPageService getUserPageService)
        {
            //_logger = logger;
            _getUserPageService = getUserPageService;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            //var t = await _getUserInformationService.CheckIfPasswordIdRightAsync("", "");

            var model = _getUserPageService.GetIndex(null);
            JsonPaywallHelper.GeneratePersonAndOrganization(out Person person, out Organization organization);
            var homeViewModel = new IndexPageViewModel()
            {
                Header = model.Header,
                Author = person,
                Organization = organization
            };

            return View(homeViewModel);
        }


        //public ActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        [HttpGet]
        [Route("Test")]
        public ActionResult Test()
        {
            var model = new SearchResultPageViewModel()
            {
                EnableTypes = true,
                Types = new List<SearchCheckboxViewModel>()
                {
                    new SearchCheckboxViewModel()
                    {
                        Id =1,
                        Label= "Infographies",
                        Checked= true
                    },
                    new SearchCheckboxViewModel()
                    {
                        Id =2,
                        Label= "Arbres décisionnels",
                        Checked= true
                    },
                    new SearchCheckboxViewModel()
                    {
                        Id =3,
                        Label= "Checklists",
                        Checked= true
                    }
                },
                SelectFilters = new List<SearchSelectsViewModel>()
                {
                    new SearchSelectsViewModel()
                    {
                        Title = "Sur le sujet",
                    Items = new List<SearchSelectItemViewModel>()
                    {
                        new SearchSelectItemViewModel()
                        {
                            Id=1,
                            Label=" Label 1",
                            Selected=true
                        },
                        new SearchSelectItemViewModel()
                        {
                            Id=2,
                            Label=" Label 2",
                            Selected=false
                        },
                        new SearchSelectItemViewModel()
                        {
                            Id=3,
                            Label=" Label 3",
                            Selected=false
                       } } } ,
                            new SearchSelectsViewModel()
                    {
                        Title = "Je recherche des contenus sur",
                    Items = new List<SearchSelectItemViewModel>()
                    {
                        new SearchSelectItemViewModel()
                        {
                            Id=1,
                            Label="Sous Label 1",
                            Selected=false
                        },
                        new SearchSelectItemViewModel()
                        {
                            Id=2,
                            Label="Sous Label 2",
                            Selected=true
                        },
                        new SearchSelectItemViewModel()
                        {
                            Id=3,
                            Label="Sous Label 3",
                            Selected=false
                       } } }

,
                        new SearchSelectsViewModel()
                    {
                            Title = "Et plus précisément sur",
                    Items = new List<SearchSelectItemViewModel>()
                    {
                        new SearchSelectItemViewModel()
                        {
                            Id=1,
                            Label=" Sujet 1",
                            Selected=false
                        },
                        new SearchSelectItemViewModel()
                        {
                            Id=2,
                            Label=" Sujet 2",
                            Selected=true
                        },
                        new SearchSelectItemViewModel()
                        {
                            Id=3,
                            Label=" Sujet 3",
                            Selected=false
                       } } } },
                Resultat = new List<SearchContentResultItem>(){
                new SearchContentResultItem()
                {
                    Id = 1,
                    Badge = "FICHE PRATIQUE",
                    Title = "Lutter contre la corruption",
                    Subject = "Prévenir et détecter la corruption",
                    CreatedAt = DateTime.Now.AddDays(-13).ToString("dd/MM/yyyy")
                },
                          new SearchContentResultItem()
                {
                    Id = 2,
                    Badge = "FICHE PRATIQUE",
                    Title = "Lutter contre la corruption",
                    Subject = "Prévenir et détecter la corruption",
                    CreatedAt = DateTime.Now.AddDays(-123).ToString("dd/MM/yyyy")
                },
                               new SearchContentResultItem()
                {
                    Id = 3,
                    Badge = "FICHE PRATIQUE",
                    Title = "Lutter contre la corruption",
                    Subject = "Prévenir et détecter la corruption",
                    CreatedAt = DateTime.Now.AddDays(-373).ToString("dd/MM/yyyy")
                },

                   new SearchContentResultItem()
                {
                    Id = 4,
                    Badge = "FICHE PRATIQUE",
                    Title = "Lutter contre la corruption",
                    Subject = "Prévenir et détecter la corruption",
                    CreatedAt = DateTime.Now.AddDays(-13).ToString("dd/MM/yyyy")
                },
                          new SearchContentResultItem()
                {
                    Id = 5,
                    Badge = "FICHE PRATIQUE",
                    Title = "Lutter contre la corruption",
                    Subject = "Prévenir et détecter la corruption",
                    CreatedAt = DateTime.Now.AddDays(-123).ToString("dd/MM/yyyy")
                }
                }
            };
            return View(model);
        }
    }
}