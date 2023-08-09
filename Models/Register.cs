﻿using System.ComponentModel.DataAnnotations;

namespace TicketManagementSystem.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
