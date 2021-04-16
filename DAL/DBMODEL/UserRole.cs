﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DBModel
{
    public partial class UserRole
    {
        public UserRole()
        {
            Emplyees = new HashSet<Emplyee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Emplyee> Emplyees { get; set; }
    }
}