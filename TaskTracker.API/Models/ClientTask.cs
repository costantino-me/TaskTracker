using System;
using System.Collections.Generic;

namespace TaskTracker.API.Models
{
    public class ClientTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}