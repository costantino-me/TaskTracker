using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.API.Helpers;
using TaskTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.API.Data
{
    public class MainRepository : IMainRepository
    {
        private readonly DataContext _context;
        public MainRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<ClientTask> GetClientTask(int clientTaskId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientTask>> GetClientTasks(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id, bool isCurrentUser)
        {
            var query = _context.Users.AsQueryable();

            if (isCurrentUser)
                query = query.IgnoreQueryFilters();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}