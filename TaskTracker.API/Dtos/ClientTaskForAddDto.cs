using System;

namespace TaskTracker.API.Dtos
{
    public class ClientTaskForAddDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ClientTaskForAddDto()
        {
            Created = DateTime.Now;        
        }
    }
}