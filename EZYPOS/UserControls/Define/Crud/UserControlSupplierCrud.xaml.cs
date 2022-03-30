using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper.Session;
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

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSupplierCrud.xaml
    /// </summary>
    public partial class UserControlSupplierCrud : UserControl
    {
        public UserControlSupplierCrud(SupplierDTO Supplier=null)
        {
            InitializeComponent();
            RefreshPage();
            if (Supplier != null)
            { InitializePage(Supplier); }
        }

        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                ddCity.ItemsSource = Db.City.GetAll().ToList();
            }
            txtFName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtId.Text = "";
            ActiveSession.NavigateToRefreshSupplierList("");
        }
        private void InitializePage(SupplierDTO Supplier)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                var SupplierData = Db.Supplier.GetAll().Where(x => x.Id == Supplier.Id).FirstOrDefault();

                if (!string.IsNullOrEmpty(SupplierData?.Name))
                {
                    txtFName.Text = SupplierData?.Name;
                    txtFName.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(SupplierData?.PhoneNo))
                {
                    txtPhone.Text = SupplierData?.PhoneNo;
                    txtPhone.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(SupplierData?.Adress))
                {
                    txtAddress.Text = SupplierData.Adress;
                    txtAddress.Foreground = Brushes.Black;
                }

                if (!string.IsNullOrEmpty(SupplierData?.MobileNo))

                {
                    txtMobile.Text = SupplierData.MobileNo;
                    txtMobile.Foreground = Brushes.Black;
                }
                if (SupplierData?.City != 0)
                {
                    ddCity.SelectedValue = SupplierData.City;
                }
                txtId.Text = SupplierData.Id.ToString();
            }

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlListSupplier());
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
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
                    int Id = Convert.ToInt32(txtId.Text);
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        var UpdateSupplier = DB.Supplier.GetAll().Where(x => x.Id == Id).FirstOrDefault();
                        if (UpdateSupplier != null)
                        {
                            if (!string.IsNullOrEmpty(txtFName.Text))
                            {
                                UpdateSupplier.Name = txtFName.Text;
                            }
                            if (!string.IsNullOrEmpty(txtPhone.Text))
                            {
                                UpdateSupplier.PhoneNo = txtPhone.Text;
                            }
                            if (!string.IsNullOrEmpty(txtMobile.Text))
                            {
                                UpdateSupplier.MobileNo = txtMobile.Text;
                            }

                            if (!string.IsNullOrEmpty(txtAddress.Text))

                            {
                                UpdateSupplier.Adress = txtAddress.Text;
                            }
                            int CityId = Convert.ToInt32(ddCity.SelectedValue);
                            if (CityId != 0)
                            {
                                UpdateSupplier.City = CityId;
                            }
                            DB.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
                            RefreshPage();
                        }
                    }
                }
            }
        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtFName.Text) || txtFName.Text == "Name")
            {
                EZYPOS.View.MessageBox.ShowCustom("Name is Required.", "Error", "OK");
                return false;

            }
            if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text == "Phone")
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    Supplier NewSupplier = new Supplier();
                    NewSupplier.Name = txtFName.Text;
                    NewSupplier.PhoneNo = txtPhone.Text;
                    NewSupplier.MobileNo = txtMobile.Text;
                    NewSupplier.Adress = txtAddress.Text;
                    NewSupplier.City = Convert.ToInt32(ddCity.SelectedValue);
                    NewSupplier.Createdon = DateTime.Today;
                    DB.Supplier.Add(NewSupplier);
                    DB.Complete();
                    EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                    RefreshPage();
                }
            }
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
                            DB.Supplier.Delete(Convert.ToInt32(txtId.Text));
                            DB.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                            RefreshPage();
                        }
                        catch
                        {
                            EZYPOS.View.MessageBox.ShowCustom("Supplier Can't be Deleted because its being Used", "Status", "OK");
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
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListSupplier());
        }
    }
}
