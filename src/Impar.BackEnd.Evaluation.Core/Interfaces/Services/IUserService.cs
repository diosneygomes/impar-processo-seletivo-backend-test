using Impar.BackEnd.Evaluation.Core.Entities;

namespace Impar.BackEnd.Evaluation.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetBatchAsync(
            int skip,
            int take);

        Task<int> GetTotalUsersAsync();
    }
}
