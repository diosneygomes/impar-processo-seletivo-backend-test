namespace Impar.BackEnd.Evaluation.Core.Interfaces.Repositories
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllAsync();
    }
}
