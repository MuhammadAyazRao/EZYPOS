using EZYPOS.Helper.Session;
using EZYPOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using DAL.Repository;
using DAL.IRepository;
using Common.Session;
using DAL.DBMODEL;

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlCustomerCrud.xaml
    /// </summary>
    public partial class UserControlCustomerCrud : UserControl
    {
        public UserControlCustomerCrud(DTO.CustomerDTO Customer=null)
        {
            InitializeComponent();
            RefreshPage();
            if (Customer != null)
            { 
                InitializePage(Customer); 
            }
        }

        private void InitializePage(CustomerDTO Customer)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Customerdata = Db.Customers.GetAll().Where(x => x.Id == Customer.Id).FirstOrDefault();

                if (!string.IsNullOrEmpty(Customerdata?.Name))
                {
                    txtFName.Text = Customerdata?.Name;
                    txtFName.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(Customerdata?.PhoneNo))
                {
                    txtPhone.Text = Customerdata?.PhoneNo;
                    txtPhone.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(Customerdata?.Adress))
                {
                    txtAddress.Text = Customerdata.Adress;
                    txtAddress.Foreground = Brushes.Black;
                }

                if (!string.IsNullOrEmpty(Customerdata?.MobileNo))

                {
                    txtMobile.Text = Customerdata.MobileNo;
                    txtMobile.Foreground = Brushes.Black;
                }
                if (Customerdata?.City != 0)
                {
                    ddCity.SelectedValue = Customerdata.City;
                }
                txtId.Text = Customerdata.Id.ToString();
            }
           
        }

        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var cities = Db.City.GetAll().ToList();
                ddCity.ItemsSource = cities;
            }
            txtFName.Text= "";
            txtPhone.Text= "";
            txtAddress.Text= "";
            txtMobile.Text= "";
            txtId.Text = "";            
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlListCustomer());
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirmed=EZYPOS.View.MessageYesNo.ShowCustom("Refresh", "Do you want to refresh page?", "Yes", "No");
            if (Isconfirmed)
            { RefreshPage(); }
        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;            
            switch (tb.Text)
            {
                case "Name":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Phone":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Mobile":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Address":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
            }
        }
        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtFName":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Name";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtPhone":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Phone";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtAddress":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Address";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtMobile":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Mobile";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;

            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (txtId.Text != "" && txtId.Text != "0")
                {
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                    {
                        var UpdateCustomer = Db.Customers.Get(Convert.ToInt32(txtId.Text));
                        if (UpdateCustomer != null)
                        {
                            if (!string.IsNullOrEmpty(txtFName.Text))
                            {
                                UpdateCustomer.Name = txtFName.Text;
                            }
                            if (!string.IsNullOrEmpty(txtPhone.Text))
                            {
                                UpdateCustomer.PhoneNo = txtPhone.Text;
                            }
                            if (!string.IsNullOrEmpty(txtMobile.Text))
                            {
                                UpdateCustomer.MobileNo = txtMobile.Text;
                            }

                            if (!string.IsNullOrEmpty(txtAddress.Text))

                            {
                                UpdateCustomer.Adress = txtAddress.Text;
                            }
                            int CityId = Convert.ToInt32(ddCity.SelectedValue);
                            if (CityId != 0)
                            {
                                UpdateCustomer.City = CityId;
                            }
                            Db.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
                            RefreshPage();
                            ActiveSession.NavigateToRefreshMenu("");
                        }
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    Customer NewCustomer = new Customer();
                    NewCustomer.Name = txtFName.Text;
                    NewCustomer.PhoneNo = txtPhone.Text;
                    NewCustomer.MobileNo = txtMobile.Text;
                    NewCustomer.Adress = txtAddress.Text;
                    NewCustomer.City = Convert.ToInt32(ddCity.SelectedValue);
                    NewCustomer.Createdon = DateTime.Now;
                    NewCustomer.RewardPoints = 0;
                    DB.Customers.Add(NewCustomer);
                    DB.Customers.Save();
                    EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                    RefreshPage();
                    ActiveSession.NavigateToRefreshMenu("");
                }
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtFName.Text) || txtFName.Text=="Name")
            {
                EZYPOS.View.MessageBox.ShowCustom("Name is Required.", "Error", "OK");
                return false;
               
            }
            if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text=="Phone")
            {
                EZYPOS.View.MessageBox.ShowCustom("Phone is Required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Address is Required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtMobile.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Mobile is Required.", "Error", "OK");
                return false;
            }
            if (ddCity.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select City.", "Error", "OK");
                return false;
            }
            return true;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete Record?", "Yes", "No");
            if (Isconfirm)
            {

                if (txtId.Text != "" && txtId.Text != "0")
                {
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        try
                        {
                            DB.Customers.Delete(Convert.ToInt32(txtId.Text));
                            DB.Customers.Save();
                            EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                            RefreshPage();
                        }
                        catch
                        {
                            EZYPOS.View.MessageBox.ShowCustom("Selected Customer Can't be Deleted because its being Used", "Status", "OK");
                        }

                    }
                }
            }
            
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListCustomer());
        }
    }
}
