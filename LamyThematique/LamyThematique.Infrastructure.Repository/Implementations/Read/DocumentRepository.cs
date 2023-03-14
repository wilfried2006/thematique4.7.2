using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamyThematique.Domain.Document;
using LamyThematique.Domain.User.Interfaces;
using LamyThematique.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LamyThematique.Infrastructure.Repository.Implementations.Read
{
    internal class DocumentRepository : BaseRepository, IDocumentRepository
    {
        public DocumentRepository(ThematiqueDbContext thematiqueDbContext) : base(thematiqueDbContext) { }

        public async Task<List<Sujet>> GetSujetsItemsAsync(int? sousThemeId = null)
        {
            return await (from sujet in DbContext.Sujets
                          where !sousThemeId.HasValue || sujet.SousThemeId == sousThemeId
                          select new Sujet()
                          {
                              Id = sujet.Id,
                              Label = sujet.Label,
                              Code = sujet.Code,
                              SousThemeId = sujet.SousThemeId
                          }).ToListAsync();
        }

        public async Task<List<SousTheme>> GetSousThemesItemsAsync(int? themeId = null)
        {
            return await (from sousTheme in DbContext.SousThemes
                          where !themeId.HasValue || sousTheme.ThemeId == themeId
                          select new SousTheme()
                          {
                              Id = sousTheme.Id,
                              Label = sousTheme.Label,
                              Code = sousTheme.Code,
                              ThemeId = sousTheme.ThemeId
                          }).ToListAsync();
        }

        public async Task<List<Theme>> GetThemesItemsAsync()
        {
            return await (from theme in DbContext.Themes
                          select new Theme()
                          {
                              Id = theme.Id,
                              Label = theme.Label,
                              Code = theme.Code
                          }).ToListAsync();
        }
    }
}
