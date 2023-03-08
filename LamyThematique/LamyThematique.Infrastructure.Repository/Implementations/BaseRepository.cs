using LamyThematique.Infrastructure.Database;

namespace LamyThematique.Infrastructure.Repository.Implementations
{
    internal class BaseRepository
    {
        public ThematiqueDbContext DbContext { get; set; }

        public BaseRepository(ThematiqueDbContext thematiqueDbContext)
        {
            DbContext = thematiqueDbContext;
        }
    }
}
