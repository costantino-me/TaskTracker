using System;

namespace TaskTracker.API.Dtos
{
    public class ClientTaskForDetailedDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}