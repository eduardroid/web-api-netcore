using dev.eduardroid.services.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dev.eduardroid.services.Data
{
    public class ServiceSeeder
    {
        private readonly ServiceContext _context;
        private readonly IWebHostEnvironment _hosting;
        public ServiceSeeder(ServiceContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Users.Any())
            {
                //add sample users
                var filePath = Path.Combine(_hosting.ContentRootPath,"Data/users.json");
                var json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                _context.Users.AddRange(users);

                _context.SaveChanges();
            }
        }
    }
}
