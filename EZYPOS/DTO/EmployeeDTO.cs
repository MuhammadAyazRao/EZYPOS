using EZYPOS.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string Cnic { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool? IsLoginAllowed { get; set; }
        public long? Salary { get; set; }
        public string Image { get; set; }
        // public List<UserPage> UserPages { get; set; }
    }
}
