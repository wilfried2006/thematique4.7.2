namespace LamyThematique.Infrastructure.Database.Entities.Base
{
    public interface IHasKey<T>
    {
        T Id { get; set; }
    }
}
