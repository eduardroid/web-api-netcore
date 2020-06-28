using dev.eduardroid.services.Data.Entities;
using System;
using System.Collections.Generic;

namespace dev.eduardroid.services.Data
{
    public interface IServiceRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool SaveAll();
        void AddEntity(Object model);
    }
}