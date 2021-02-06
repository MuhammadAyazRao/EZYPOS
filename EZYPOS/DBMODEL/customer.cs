using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.DBMODEL
{
    public class customer
    {
        public int id { get; set; }
        public Nullable<int> restaurant_id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_old { get; set; }
        public string house { get; set; }
        public string door_num { get; set; }
        public string town { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
        public string address { get; set; }
        public string comments { get; set; }
        public string bill_name { get; set; }
        public string bill_surname { get; set; }
        public string bill_zipcode { get; set; }
        public string bill_town { get; set; }
        public string bill_street { get; set; }
        public string bill_email { get; set; }
        public string addon { get; set; }
        public string addby { get; set; }
        public string updateon { get; set; }
        public string updateby { get; set; }
        public string status { get; set; }
        public Nullable<int> subscribed_email { get; set; }
        public Nullable<int> subscribed_sms { get; set; }
        public Nullable<int> update_order_by_sms { get; set; }
        public Nullable<int> update_order_by_email { get; set; }
        public string bill_phone { get; set; }
        public string bill_door_num { get; set; }
        public string customer_comments { get; set; }
        public string store_card { get; set; }
        public string braintree_token { get; set; }
        public string remember_card { get; set; }
        public string is_social { get; set; }
        public string social_user_id { get; set; }
        public string pass_reset_request { get; set; }
        public Nullable<int> pass_reset_code { get; set; }
        public string api_token { get; set; }
        public string fbid { get; set; }
        public string gid { get; set; }
        ///public static List<customer> CustomerList = new List<customer>();

        public static List<customer> GetCustomers()
        {
            List<customer> CustomerList = new List<customer>();
            CustomerList.Add(new customer { bill_name = "Muhammad", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony", bill_zipcode="Dl15" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Bilal", bill_surname = "Muhammad", bill_phone = "03215115527", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Saud", bill_surname = "Muhammad", bill_phone = "0321", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });
            CustomerList.Add(new customer { bill_name = "Ayaz", bill_surname = "Muhammad", bill_phone = "03075183504", bill_email = "ayaz@gmail.com", bill_door_num = "46", bill_street = "3", bill_town = "Liaqat colony" });

            return CustomerList;
        }

        public static void AddCustomer(customer Cust)
        {
           // CustomerList.Add(Cust);
        }
        }
}
