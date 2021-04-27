using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.Helper
{
    public class Pager<T>
    {
        //public int numberOfRecPerPage = 10;
        //List<T> myList { get; set; }
        public int PageIndex = 0;
        List<T> PagedList = new List<T>();        

        public List<T> Last(List<T> ListToPage, int RecordsPerPage=10)
        {
            PageIndex = ListToPage.Count / RecordsPerPage;
            if (ListToPage.Count % RecordsPerPage == 0)
            {
                PageIndex--;
            }
            PagedList = SetPaging(ListToPage, RecordsPerPage);
            return PagedList;
        }
        public List<T> First(List<T> ListToPage, int RecordsPerPage=10)
        {
            PageIndex = 0;
            PagedList = SetPaging(ListToPage, RecordsPerPage);
            return PagedList;
        }
        public List<T> Next(List<T> ListToPage, int RecordsPerPage=10)
        {
            PageIndex++;
            if (PageIndex >= ListToPage.Count / RecordsPerPage)
            {
                PageIndex = ListToPage.Count / RecordsPerPage;
                if (ListToPage.Count % RecordsPerPage == 0)
                {
                    PageIndex--;
                }
            }
            PagedList = SetPaging(ListToPage, RecordsPerPage);
            return PagedList;
        }
        public List<T> Previous(List<T> ListToPage, int RecordsPerPage = 10)
        {
            PageIndex--;
            if (PageIndex <= 0)
            {
                PageIndex = 0;
            }
            PagedList = SetPaging(ListToPage, RecordsPerPage);
            return PagedList;
        }

        public List<T> SetPaging(List<T> ListToPage, int RecordsPerPage=10)
        {
            int PageGroup = PageIndex * RecordsPerPage;

            List<T> PagedList = new List<T>();

            PagedList = ListToPage.Skip(PageGroup).Take(RecordsPerPage).ToList(); //This is where the Magic Happens. If you have a Specific sort or want to return ONLY a specific set of columns, add it to this LINQ Query.

            //DataTable FinalPaging = PagedTable<T>(PagedList);

            return PagedList;
        }


        private DataTable PagedTable<G>(List<T> SourceList)
        {
            Type columnType = typeof(T);
            DataTable TableToReturn = new DataTable();

            foreach (var Column in columnType.GetProperties())
            {
                TableToReturn.Columns.Add(Column.Name, Column.PropertyType);
            }

            foreach (object item in SourceList)
            {
                DataRow ReturnTableRow = TableToReturn.NewRow();
                foreach (var Column in columnType.GetProperties())
                {
                    ReturnTableRow[Column.Name] = Column.GetValue(item);
                }
                TableToReturn.Rows.Add(ReturnTableRow);
            }
            return TableToReturn;
        }
        public string PageNumberDisplay(List<T> SourceList,int numberOfRecPerPage=10)
        {
            int PagedNumber = numberOfRecPerPage * (PageIndex + 1);
            if (PagedNumber > SourceList.Count)
            {
                PagedNumber = SourceList.Count;
            }
            return "Showing " + PagedNumber + " of " + SourceList.Count; //This dramatically reduced the number of times I had to write this string statement
        }
    }
}
