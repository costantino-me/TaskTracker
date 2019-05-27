using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TaskTracker.API.Models;

namespace TaskTracker.API.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<ClientTask> ClientTasks { get; set; }
    }
}