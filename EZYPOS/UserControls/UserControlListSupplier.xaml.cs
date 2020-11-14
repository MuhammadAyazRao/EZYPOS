using EZYPOS.DBModels;
using EZYPOS.DTO;
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
            using (EPOSDBContext DB = new EPOSDBContext())
            {
                var SupplierData = DB.Suppliers.Select(x => new SupplierDTO { Id = x.Id, Name = x.Name, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, PhoneNo = x.PhoneNo, Adress = x.Adress }).ToList();                
                SupplierGrid.ItemsSource = SupplierData;
            }
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlSupplierCrud());
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<Supplier> SupplerData;
            using (EPOSDBContext DB = new EPOSDBContext())
            {
                if (StartDate.SelectedDate==null && EndDate.SelectedDate==null)
                {
                    SupplerData = DB.Suppliers.ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                     SupplerData = DB.Suppliers.Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }
                
                SupplierGrid.ItemsSource = SupplerData;
            }

        }

      

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.SupplierDTO SupplierDTO = (EZYPOS.DTO.SupplierDTO)SupplierGrid.SelectedItem;
            ActiveSession.NavigateToSwitchScreen(new UserControlSupplierCrud(SupplierDTO));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            //restCust selectedCust = (restCust)SupplierGrid.SelectedValue;
            //UnitOfWork uow = new UnitOfWork(new EPOSEntities());
            //uow.restCusts.Remove(uow.restCusts.Find(x => x.pkcode == selectedCust.pkcode));
            //uow.Complete();
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

    }
}
