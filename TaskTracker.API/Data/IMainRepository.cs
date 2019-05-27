using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.API.Helpers;
using TaskTracker.API.Models;
using TaskTracker.API.Models;

namespace TaskTracker.API.Data
{
    public interface IMainRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id, bool isCurrentUser);
         Task<ClientTask> GetClientTask(int clientTaskId);
         Task<IEnumerable<ClientTask>> GetClientTasks(int userId);         
    }
}