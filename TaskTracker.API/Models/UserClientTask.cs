using TaskTracker.API.Models;

namespace TaskTracker.API.Models
{
    public class UserClientTask
    {
        public int UserId { get; set; }
        public int ClientTaskId { get; set; }        
        public User User { get; set; }
        public ClientTask ClientTask { get; set; }
    }
}