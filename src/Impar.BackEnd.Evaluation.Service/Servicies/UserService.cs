
using Impar.BackEnd.Evaluation.Core.Entities;
using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Core.Interfaces.Services;

namespace Impar.BackEnd.Evaluation.Service.Servicies
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users =  await this._userRepository
                .GetAllAsync()
                .ConfigureAwait(false);

            return users;
        }
    }
}
