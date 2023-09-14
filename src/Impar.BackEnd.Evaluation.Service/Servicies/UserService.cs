
using Impar.BackEnd.Evaluation.Core.Entities;
using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Core.Interfaces.Services;
using Impar.BackEnd.Evaluation.Service.Exceptions;

namespace Impar.BackEnd.Evaluation.Service.Servicies
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetBatchAsync(
            int skip,
            int take)
        {
            if (take > 1000)
            {
                throw new GetEntityException("Não é possível obter mais de 1000 registros em uma única consulta.");
            }

            var users =  await this._userRepository
                .GetBatchAsync(
                    skip,
                    take)
                .ConfigureAwait(false);

            return users;
        }

        public async Task<int> GetTotalUsersAsync()
        {
            var total = await this._userRepository
                .GetTotalUsersAsync()
                .ConfigureAwait(false);

            return total;
        }
    }
}
