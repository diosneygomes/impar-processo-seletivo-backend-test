﻿using Impar.BackEnd.Evaluation.Core.Entities;

namespace Impar.BackEnd.Evaluation.Core.Interfaces.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task AddAsync(Message message);
    }
}
