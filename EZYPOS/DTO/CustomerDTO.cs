using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DTO
{

    public  class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set; }

    }
    //public class customer
    //{
    //    public static Customer DBCustomertoUI(EZYPOS.DBModels.Customer UICustomer)
    //    {
    //        Customer DBCustomer = new Customer();
    //        DBCustomer.Id = UICustomer.Id;
    //        DBCustomer.Name = UICustomer.Name;
    //        DBCustomer.PhoneNo = UICustomer.PhoneNo;
    //        DBCustomer.Adress = UICustomer.Adress;
    //        DBCustomer.City = UICustomer.CityNavigation == null ? null : UICustomer.CityNavigation.CityName;
    //        return DBCustomer;
    //    }

    //}
}
