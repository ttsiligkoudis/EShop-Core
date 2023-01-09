﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
    }
}