using System;
using System.Collections.Generic;
using TaskTracker.API.Models;

namespace TaskTracker.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}