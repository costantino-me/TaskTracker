using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TaskTracker.API.Models;

namespace TaskTracker.API.Models
{
    public class User : IdentityUser<int>
    {
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserClientTask> UserClientTasks { get; set; }
    }
}