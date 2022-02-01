using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.Helper
{
    public class Months
    {
        public string Name;
        public int Id;
    }
    public class Month
    {
        public static List<Months> Months = new List<Months>();

        public static List<Months> GetMonths()
        {
           
            Months.Add(new Months { Name = "January", Id = 1 });
            Months.Add(new Months { Name = "Febuary", Id = 2 });
            Months.Add(new Months { Name = "March", Id = 3 });
            Months.Add(new Months { Name = "April", Id = 4 });
            Months.Add(new Months { Name = "May", Id = 5 });
            Months.Add(new Months { Name = "June", Id = 6 });
            Months.Add(new Months { Name = "July", Id = 7 });
            Months.Add(new Months { Name = "August", Id = 8 });
            Months.Add(new Months { Name = "September", Id = 9 });
            Months.Add(new Months { Name = "October", Id = 10 });
            Months.Add(new Months { Name = "November", Id = 11 });
            Months.Add(new Months { Name = "December", Id = 12 });
            return Months;
        }

        public static string GetMonthName(int Id)
        {
            if (Months == null || Months.Count <= 0)
            { 
                GetMonths(); 
            }
            return Months.Where(x => x.Id == Id).FirstOrDefault().Name;
           
        }

        internal static object GetMonthName()
        {
            throw new NotImplementedException();
        }
    }
}
