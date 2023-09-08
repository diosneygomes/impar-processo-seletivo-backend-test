﻿using Impar.BackEnd.Evaluation.Core.Entities;

namespace Impar.BackEnd.Evaluation.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
