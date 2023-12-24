﻿using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Models.CustomerUserModels
{
    /// <summary>
    /// Holds AllCustomerUsersModel class.
    /// </summary>
    public class AllCustomerUsersModel
    {
        [Required]
        public int CustomerUserId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; } = null!;
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public IEnumerable<Customer> Customers = new List<Customer>();
    }
}
