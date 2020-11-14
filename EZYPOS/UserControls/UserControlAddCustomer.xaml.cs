
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

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlAddCustomer.xaml
    /// </summary>
    public partial class UserControlAddCustomer : UserControl
    {
        public UserControlAddCustomer()
        {
            InitializeComponent();
            
            //    List<String> names = new List<string>();
            //    names.Add("WPF rocks");
            //    names.Add("WCF rocks");
            //    names.Add("XAML is fun");
            //    names.Add("WPF rules");
            //    names.Add("WCF rules");
            //    names.Add("WinForms not");
            //    names.Add("WPF1 rocks");
            //    names.Add("WCF1 rocks");
            //    names.Add("XAML1 is fun");
            //    names.Add("WPF 1rules");
            //    names.Add("WCF1 1rules");
            //    names.Add("WinForms1 not");

            //    //FilteredComboBox1.IsEditable = true;
            //    //FilteredComboBox1.IsTextSearchEnabled = false;
            //    FilteredComboBox1.ItemsSource = customer.GetCustomers();
        }

        public UserControlAddCustomer(CustomerDTO Customer=null)
        {
            InitializeComponent();
           
            if (Customer != null)
            { 
                //txtFName.Text = Customer.bill_name;
            //    txtLName.Text = Customer.surname;
            //    txtDob.Text ="08/08/2020";
            //    Date.Text ="08/08/2020";
            //    FilteredComboBox1.SelectedValue = "0321";

            }
            
           // FilteredComboBox1.ItemsSource = customer.GetCustomers();
        }




        private void txtDob_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (txtDob.Text == string.Empty)
            //{
            //    txtDob.Text = "dd/mm/yyyy";
            //    txtDob.Foreground = Brushes.Gray;
            //}
        }

        private void txtDob_GotFocus(object sender, RoutedEventArgs e)
        {
            //if (txtDob.Text == "dd/mm/yyyy")
            //    txtDob.Text = "";
            //txtDob.Foreground = Brushes.Black;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlListCustomer());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //restCust customer = new restCust();
            //customer.fkrest = ActiveSession.restaurant.pkcode;
            //customer.fname = txtFName.Text;
            //customer.lname = txtLName.Text;
            //customer.email = txtEmail.Text;

            //if(txtDob.Text != "dd/mm/yyyy")
            //{
            //    try { customer.dob = DateTime.ParseExact(txtDob.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
            //    catch { MessageBoxUI.ShowCustom("Date is not in specific format", "Date of Birth Input Error", "Ok"); }
            //}

            //customer.phone1 = txtCont1.Text;
            //customer.phone2 = txtCont2.Text;
            //customer.HomeNo = txtHome.Text;
            //customer.Address = txtAddress.Text;
            //customer.PostalCode = txtPostal.Text;
            //customer.note = txtNote.Text;

            //if (string.IsNullOrWhiteSpace(customer.fname) || string.IsNullOrWhiteSpace(customer.phone1))
            //{
            //    MessageBoxUI.ShowCustom("Please provide data for mandatory (*) fields", "Input Error", "OK");
            //    return;
            //}
            //else
            //{
            //    if(isUpdate)
            //    {
            //        uow.restCusts.Update(customer, customer.pkcode);
            //        int i = uow.Complete();
            //        if (i == 1)
            //            MessageBoxUI.ShowCustom("Data successfully updated.", "Data Updated", "OK");
            //    }
            //    else
            //    {
            //        uow.restCusts.Add(customer);
            //        int i = uow.Complete();
            //        if (i == 1)
            //            MessageBoxUI.ShowCustom("Data saved successfully.", "Data Saved", "OK");
            //    }

            //}
        }

        private void txtDob_Keydown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Back)
            {
                if (txtDob.Text.Length == 2 || txtDob.Text.Length == 5)
                {
                    txtDob.Text += "/";
                    txtDob.CaretIndex = txtDob.Text.Length;
                }
            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            txtFName.Text = "FirstName";
            Date.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // customer NewCustomer = new customer();
           // NewCustomer.bill_name = txtFName.Text;
           // NewCustomer.surname = txtLName.Text;
           //// NewCustomer.address = txtPostal.Text;
           // NewCustomer.updateon = Date.Text;

           // customer.AddCustomer(NewCustomer);

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
           // customer NewCustomer = new customer();
           // NewCustomer.bill_name = txtFName.Text;
           // NewCustomer.surname = txtLName.Text;
           // NewCustomer.bill_street = "3";
           // NewCustomer.bill_door_num = "37";
           // NewCustomer.bill_town = "Shamsabad";
           //// NewCustomer.bill_zipcode = txtPostal.Text;
           // NewCustomer.updateon = Date.Text;
           // customer.AddCustomer(NewCustomer);
           // MessageBox.Show("Record Saved");

        }
    }
}
