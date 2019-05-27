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

        public async Task<ClientTask> GetClientTask(int clientTaskId)
        {
            var query = _context.ClientTasks.AsQueryable();

            var user = await query.FirstOrDefaultAsync(t => t.Id == clientTaskId);

            return user;
        }

        public async Task<IEnumerable<ClientTask>> GetClientTasks()
        {
            var clientTasks = _context.ClientTasks;
            return clientTasks;
        }

        public async Task<User> GetUser(int id)
        {
            var query = _context.Users.Include(u => u.ClientTasks).AsQueryable();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users.Include(u => u.ClientTasks).AsQueryable();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}