﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationHelper.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string Name { get; set; }
    }
}
