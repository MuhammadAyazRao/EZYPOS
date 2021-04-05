
using EZYPOS.DBModels;
using EZYPOS.Helper.Session;
using EZYPOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using EZYPOS.Helper;
using DAL.Repository;

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlListCustomer.xaml
    /// </summary>
    public partial class UserControlListCustomer : UserControl
    {
        List<CustomerDTO> myList { get; set; }
        Pager<CustomerDTO> Pager = new Helper.Pager<CustomerDTO>();
        public UserControlListCustomer()
        {            
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender= null)
        {
           
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                myList = DB.Customers.GetAll().Select(x => new CustomerDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation.CityName == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();
                //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView; //Fill a DataTable with the First set based on the numberOfRecPerPage                 
                ResetPaging(myList);
            }
        }        

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Dispatcher.Invoke((Action)delegate {
                ActiveSession.CloseDisplayuserControlMethod(new UserControlCustomerCrud());

            //});
            //Task.Run(() => ActiveSession.CloseDisplayuserControlMethod(new UserControlCustomerCrud()));
           // ActiveSession.CloseDisplayuserControlMethod(new UserControlCustomerCrud());
           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.Key == Key.Enter)
            //    {
            //        string searchTest = textBoxSearch.Text.ToLower();

            //        //        List<customer> customers = context.customers.Where(x =>
            //        //    x.restaurant_id == ActiveSession.Restaurant.id
            //        //).ToList(); ;
            //        List<customer> customers = context.customers.ToList();
            //        List<customer> filterCustomers = new List<customer>();


            //        filterCustomers = customers.Where(x => x.bill_name.ToLower().Contains(searchTest)).ToList();
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }

            //        filterCustomers = customers.Where(x => x.bill_phone.ToLower().Contains(searchTest)).ToList();
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }


            //        filterCustomers = customers.Where(x => x.bill_surname != null).ToList();
            //        filterCustomers = filterCustomers.Where(x => x.bill_surname.ToLower().Contains(searchTest)).ToList();
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }


            //        filterCustomers = customers.Where(x => x.bill_zipcode != null).ToList();
            //        filterCustomers = filterCustomers.Where(x => x.bill_zipcode.ToLower().Contains(searchTest)).ToList();
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }


            //        filterCustomers = customers.Where(x => x.bill_door_num != null).ToList();
            //        filterCustomers = filterCustomers.Where(x => x.bill_door_num.ToLower().Contains(searchTest)).ToList();
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }


            //        filterCustomers = customers.Where(x => x.bill_street != null).ToList();
            //        filterCustomers = filterCustomers.Where(x => x.bill_street.ToLower().Contains(searchTest)).ToList();
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }


            //        filterCustomers = customers.Where(x => x.bill_town != null).ToList();
            //        filterCustomers = filterCustomers.Where(x => x.bill_town.ToLower().Contains(searchTest)).ToList();
            //        if (customers.Count >= filterCustomers.Count && filterCustomers.Count != 0)
            //        {
            //            customerGrid.ItemsSource = filterCustomers;
            //            return;
            //        }


            //        //customerGrid.ItemsSource = customers.Where(x =>
            //        //    x.bill_name.ToUpper().Contains(textBoxSearch.Text.ToUpper()) ||
            //        //    x.bill_surname.ToUpper().Contains(textBoxSearch.Text.ToUpper()) ||
            //        //    x.bill_zipcode.ToUpper().Contains(textBoxSearch.Text.ToUpper()) ||
            //        //    x.bill_door_num.ToUpper().Contains(textBoxSearch.Text.ToUpper()) ||
            //        //    x.bill_street.ToUpper().Contains(textBoxSearch.Text.ToUpper()) ||
            //        //    x.bill_town.ToUpper().Contains(textBoxSearch.Text.ToUpper())
            //        //);


            //        if (filterCustomers.Count == 0)
            //            MessageBox.ShowCustom("No customer exist.", "Searching Customer", "Ok");

            //    }

            //    if (textBoxSearch.Text.Length == 0)
            //        customerGrid.ItemsSource = context.customers.ToList();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.ShowCustom(ex.Message, "Customer", "Ok");

            //}

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {            
          
            EZYPOS.DTO.CustomerDTO CustomerObj = (EZYPOS.DTO.CustomerDTO)customerGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCustomerCrud(CustomerObj));
            //ActiveSession.NavigateToSwitchScreen(new UserControlCustomerCrud(CustomerObj));
           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {          
            
        }
       

        private void Search_Click(object sender, RoutedEventArgs e)
        {                
            using (EPOSDBContext DB = new EPOSDBContext())
            {
                List<Customer> CustomerData;
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    CustomerData = DB.Customers.ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    CustomerData = DB.Customers.Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }
                customerGrid.ItemsSource = CustomerData;
            }
            
        }       

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        myList = DB.Customers.GetAll().Select(x => new CustomerDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();
                        ResetPaging(myList);
                    }
                    else
                    {
                        //cv.Filter = o =>
                        {
                            //using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                            {
                                // myList = DB.Customers.GetAll().Select(x => new CustomerDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();

                                if (t.Name == "GridName")
                                {
                                    myList = DB.Customers.GetAll().Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList().Select(x => new CustomerDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();
                                    ResetPaging(myList);
                                   // ResetPaging(myList.Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList());
                                }
                                if (t.Name == "GridContact")
                                {
                                    myList = DB.Customers.GetAll().Where(x => x.PhoneNo.ToUpper().Contains(filter.ToUpper())).ToList().Select(x => new CustomerDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();
                                    ResetPaging(myList);
                                    //ResetPaging(myList.Where(x => x.PhoneNo.ToUpper().Contains(filter.ToUpper())).ToList());
                                }
                                if (t.Name == "GridCity")
                                {
                                    myList = DB.Customers.GetAll().Where(x => x.CityNavigation.CityName.ToUpper().Contains(filter.ToUpper())).ToList().Select(x => new CustomerDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();
                                    ResetPaging(myList);
                                   // ResetPaging(myList.Where(x => x.City.ToUpper().Contains(filter.ToUpper())).ToList());
                                }
                                if (t.Name == "GridAdress")
                                {
                                    myList = DB.Customers.GetAll().Where(x => x.Adress.ToUpper().Contains(filter.ToUpper())).ToList().Select(x => new CustomerDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();
                                    ResetPaging(myList);
                                   // ResetPaging(myList.Where(x => x.Adress.ToUpper().Contains(filter.ToUpper())).ToList());
                                }
                                //else
                                //{
                                //    ResetPaging(myList);
                                //}
                                //ResetPaging(myList);
                            }
                        };
                    }
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<CustomerDTO> ListTopagenate)
        {
            customerGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            customerGrid.ItemsSource =Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            customerGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)  //I couldn't get this function to update in place (if the grid showed 20 and I selected 100 it would jump to 200)
        {                                                                                          //So instead I had it call the First function and that does an acceptable job.
           // numberOfRecPerPage = Convert.ToInt32(NumberOfRecords.SelectedItem);
            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
            //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
            //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
            //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
            //PageInfo.Content = PageNumberDisplay();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            customerGrid.ItemsSource =Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {customerGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        //public string PageNumberDisplay()
        //{
        //    int PagedNumber = numberOfRecPerPage * (PageIndex + 1);
        //    if (PagedNumber > myList.Count)
        //    {
        //        PagedNumber = myList.Count;
        //    }
        //    return "Showing " + PagedNumber + " of " + myList.Count; //This dramatically reduced the number of times I had to write this string statement
        //}

        //public DataTable Last(IList<CustomerDTO> ListToPage, int RecordsPerPage)
        //{
        //    PageIndex = ListToPage.Count / RecordsPerPage;
        //    PagedList = SetPaging(ListToPage, RecordsPerPage);
        //    return PagedList;
        //}
        //public DataTable First(List<CustomerDTO> ListToPage, int RecordsPerPage)
        //{
        //    PageIndex = 0;     
        //    PagedList = SetPaging(ListToPage, RecordsPerPage);
        //    return PagedList;
        //}
        //public DataTable Previous(IList<CustomerDTO> ListToPage, int RecordsPerPage)
        //{
        //    PageIndex--;
        //    if (PageIndex <= 0)
        //    {
        //        PageIndex = 0;
        //    }
        //    PagedList = SetPaging(ListToPage, RecordsPerPage);
        //    return PagedList;
        //}
        //public DataTable Next(IList<CustomerDTO> ListToPage, int RecordsPerPage)
        //{
        //    PageIndex++;
        //    if (PageIndex >= ListToPage.Count / RecordsPerPage)
        //    {
        //        PageIndex = ListToPage.Count / RecordsPerPage;
        //    }
        //    PagedList = SetPaging(ListToPage, RecordsPerPage);
        //    return PagedList;
        //}


        //public DataTable SetPaging(IList<CustomerDTO> ListToPage, int RecordsPerPage)
        //{
        //    int PageGroup = PageIndex * RecordsPerPage;

        //    IList<CustomerDTO> PagedList = new List<CustomerDTO>();

        //    PagedList = ListToPage.Skip(PageGroup).Take(RecordsPerPage).ToList(); //This is where the Magic Happens. If you have a Specific sort or want to return ONLY a specific set of columns, add it to this LINQ Query.

        //    DataTable FinalPaging = PagedTable(PagedList);

        //    return FinalPaging;
        //}

        //private DataTable PagedTable<T>(IList<T> SourceList)
        //{
        //    Type columnType = typeof(T);
        //    DataTable TableToReturn = new DataTable();

        //    foreach (var Column in columnType.GetProperties())
        //    {
        //        TableToReturn.Columns.Add(Column.Name, Column.PropertyType);
        //    }

        //    foreach (object item in SourceList)
        //    {
        //        DataRow ReturnTableRow = TableToReturn.NewRow();
        //        foreach (var Column in columnType.GetProperties())
        //        {
        //            ReturnTableRow[Column.Name] = Column.GetValue(item);
        //        }
        //        TableToReturn.Rows.Add(ReturnTableRow);
        //    }
        //    return TableToReturn;
        //}
        #endregion

    }
}
