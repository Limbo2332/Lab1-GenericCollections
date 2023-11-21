﻿using NewsSite.DAL.Entities;

namespace NewsSite.DAL.Repositories.Base
{
    public interface IAuthorsRepository : IGenericRepository<Author>
    {
        Task<Author> GetAuthorByEmailAsync(string email);
    }
}