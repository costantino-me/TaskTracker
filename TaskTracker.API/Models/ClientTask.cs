using System;
using System.Collections.Generic;

namespace TaskTracker.API.Models
{
    public class ClientTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public ICollection<UserClientTask> UserClientTasks { get; set; }
    }
}