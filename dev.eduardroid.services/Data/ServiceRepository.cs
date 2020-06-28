using dev.eduardroid.services.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.eduardroid.services.Data
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ServiceContext _context;
        private readonly ILogger<ServiceRepository> _logger;

        public ServiceRepository(ServiceContext context,ILogger<ServiceRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddEntity(Object model)
        {
            _context.Add(model);
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _context.Users
                            .OrderBy(u => u.Nickname)
                            .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }

        }

        public User GetUserById(Int32 id)
        {
            try 
            { 
                return _context.Users
                            .Where(u => u.Id == id)
                            .First();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
}

        public bool SaveAll()
        {
            try { 
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
}
    }
}
