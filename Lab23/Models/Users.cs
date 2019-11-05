using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab23.Models
{
    public partial class Users
    { 
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Funds { get; set; }
    }
}
