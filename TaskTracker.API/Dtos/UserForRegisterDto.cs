using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 12, ErrorMessage = "You must specify a password of at least 12 characters.")]
        [RegularExpression(@"(^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$)", ErrorMessage = "You must specify a password between 12 and 30 characters, alphanumeric with special characters.")]
        public string Password { get; set; }
        public DateTime Created { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}