
using EZYPOS.DBMODEL;
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
    /// Interaction logic for UserControlListCustomer.xaml
    /// </summary>
    public partial class UserControlListCustomer : UserControl
    {
        public UserControlListCustomer()
        {
            InitializeComponent();
           
           customerGrid.ItemsSource = customer.GetCustomers().ToList();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            //CustomerWindow win = new CustomerWindow();
            //win.Show();
            ActiveSession.NavigateToSwitchScreen(new UserControlAddCustomer());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Close();
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
            
            var customer = (customer)customerGrid.SelectedItem;
            ActiveSession.NavigateToSwitchScreen(new UserControlAddCustomer(customer));
            //AddCommentPopUp popUp = new AddCommentPopUp();
            //if ((bool)popUp.ShowDialog())
            //{
            //    try
            //    {
            //        customer customer = (customer)customerGrid.SelectedItem;
            //        context.Entry<customer>(customer).Entity.comments = popUp.Text;
            //        context.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Epos.Views.MessageBox.ShowCustom(ex.Message, "Error", "ok");
            //    }
            //}
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            //restCust selectedCust = (restCust)customerGrid.SelectedValue;
            //UnitOfWork uow = new UnitOfWork(new EPOSEntities());
            //uow.restCusts.Remove(uow.restCusts.Find(x => x.pkcode == selectedCust.pkcode));
            //uow.Complete();
        }

        private void textBoxSearch_TouchDown(object sender, TouchEventArgs e)
        {
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //AppHelper.OnScreenKeyboardConfiguration.ShowOnScreenKeyBoard();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{

            //    {
            //        string searchTest = textBoxSearch.Text.ToLower();
            //        //List<customer> customers = context.customers.Where(x =>x.restaurant_id == ActiveSession.Restaurant.id).ToList();
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
            //    MessageBox.ShowCustom(ex.Message, "Customer Error", "Ok");

            //}
        }

        private void GridName_TextChanged(object sender, TextChangedEventArgs e)
        {
          //  if (e.Key != Key.Back)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(customerGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        customer p = o as customer;
                        if (t.Name == "GridName")
                        {     //return (p.Id == Convert.ToInt32(filter));

                            return (p.bill_name.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        else if (t.Name == "GridContact")
                        {
                            return (p.bill_phone.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        else
                        {
                            return true;
                        }
                    };
                }
            }
           
        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(customerGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        customer p = o as customer;
                        if (t.Name == "GridName")
                        {     //return (p.Id == Convert.ToInt32(filter));

                                return (p.bill_name.ToUpper().StartsWith(filter.ToUpper()) || p.bill_surname.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        else if (t.Name == "GridContact")
                        {
                            return (p.bill_phone.ToUpper().StartsWith(filter.ToUpper()));
                        }
                        else
                        {
                            return true;
                        }

                    };
                }
            }

        }
    }
}
