﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

    }
}
