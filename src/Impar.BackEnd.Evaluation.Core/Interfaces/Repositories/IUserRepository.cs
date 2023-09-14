using Impar.BackEnd.Evaluation.Core.Entities;

namespace Impar.BackEnd.Evaluation.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetBatchAsync(
            int skip,
            int take);

        Task<int> GetTotalUsersAsync();
    }
}
