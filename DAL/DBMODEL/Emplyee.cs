using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAL.DBModel
{
    public partial class Emplyee
    {
        public Emplyee()
        {
            UserPages = new HashSet<UserPage>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        [ForeignKey("Role")]
        public int? Role { get; set; }
        [ForeignKey("City")]
        public int? City { get; set; }
        public string Cnic { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public bool? Isdeleted { get; set; }
        public DateTime? Createdon { get; set; }
        public string Password { get; set; }
        public bool? IsLoginAllowed { get; set; }
        public long? Salary { get; set; }
        public string Image { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual UserRole RoleNavigation { get; set; }
        public virtual ICollection<UserPage> UserPages { get; set; }
    }
}
