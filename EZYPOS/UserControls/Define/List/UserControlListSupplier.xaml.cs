using Common.Session;
using DAL.DBModel;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.Helper.Session;
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

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlListSupplier.xaml
    /// </summary>
    public partial class UserControlListSupplier : UserControl
    {
        List<SupplierDTO> myList { get; set; }
        Pager<SupplierDTO> Pager = new Helper.Pager<SupplierDTO>();
        public UserControlListSupplier(bool Ismenu=false)
        {
            if (Ismenu)
            {
                ActiveSession.RefreshSupplierList += Refresh;
            }
            InitializeComponent();
            Refresh();
        }

        private void Refresh(object sender=null)
        {
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                myList = DB.Supplier.GetAll().Select(x => new SupplierDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();
                ResetPaging(myList);
            }
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSupplierCrud());
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                myList = DB.Supplier.GetAll().Select(x => new SupplierDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress, Createdon = x.Createdon }).ToList();

                if (StartDate.SelectedDate != null && EndDate.SelectedDate != null)
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = myList.Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }
                SupplierGrid.ItemsSource = myList;
            }

        }
      

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.SupplierDTO SupplierDTO = (EZYPOS.DTO.SupplierDTO)SupplierGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSupplierCrud(SupplierDTO));
        }
          
        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(SupplierGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        EZYPOS.DTO.SupplierDTO List = o as EZYPOS.DTO.SupplierDTO;

                        if (t.Name == "GridName")
                        {
                            return List.Name.ToUpper().StartsWith(filter.ToUpper());
                            // return (p.bill_name.ToUpper().StartsWith(filter.ToUpper()) || p.bill_surname.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        if (t.Name == "GridContact")
                        {
                            return List.PhoneNo.ToUpper().StartsWith(filter.ToUpper());
                            // return (p.bill_name.ToUpper().StartsWith(filter.ToUpper()) || p.bill_surname.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        if (t.Name == "GridCity")
                        {
                            return List.City.ToUpper().StartsWith(filter.ToUpper());
                            // return (p.bill_name.ToUpper().StartsWith(filter.ToUpper()) || p.bill_surname.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        if (t.Name == "GridAdress")
                        {
                            return List.Adress.ToUpper().StartsWith(filter.ToUpper());
                            // return (p.bill_name.ToUpper().StartsWith(filter.ToUpper()) || p.bill_surname.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        else
                        {
                            return true;
                        }
                        //else if (t.Name == "GridContact")
                        //{
                        //   // return (p.bill_phone.ToUpper().StartsWith(filter.ToUpper()));
                        //}


                    };
                }
            }

        }
        #region Pagination

        private void ResetPaging(List<SupplierDTO> ListTopagenate)
        {
            SupplierGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            SupplierGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            SupplierGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            SupplierGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SupplierGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

       
        #endregion

    }
}
