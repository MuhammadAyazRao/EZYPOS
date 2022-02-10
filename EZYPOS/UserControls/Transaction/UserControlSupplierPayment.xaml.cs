using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
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

namespace EZYPOS.UserControls.Transaction
{
    /// <summary>
    /// Interaction logic for UserControlSupplierPayment.xaml
    /// </summary>
    public partial class UserControlSupplierPayment : UserControl
    {
        public UserControlSupplierPayment(SupplierPaymentDTO Sp = null)
        {
            InitializeComponent();
            RefreshPage();
            if (Sp != null)
            {
                InitializePage(Sp);
            }
        }
        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;
            TransactionDate.SelectedDate = DateTime.Today;
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DDSupplier.ItemsSource = Db.Supplier.GetAll().ToList();
                DDPayedBy.ItemsSource = Db.Employee.GetAll().ToList();
            }
            txtDiscription.Text = "";
            txtAmount.Text = "";
            txtId.Text = "";
        }
        private void InitializePage(SupplierPaymentDTO Sp)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var SupplierPaymentData = Db.SupplierPayment.Get(Sp.Id);

                if (!string.IsNullOrEmpty( Convert.ToString(SupplierPaymentData?.Amount)))
                {
                    txtAmount.Text = Convert.ToString(SupplierPaymentData?.Amount);
                    txtAmount.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(SupplierPaymentData?.Discription))
                {
                    txtDiscription.Text = SupplierPaymentData?.Discription;
                    txtDiscription.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(SupplierPaymentData?.TransactionDate)))
                {
                    TransactionDate.Text = Convert.ToString(SupplierPaymentData?.TransactionDate);
                    
                }
                if (!string.IsNullOrEmpty(Convert.ToString(SupplierPaymentData?.EmployeeId)))
                {
                    DDPayedBy.SelectedValue = SupplierPaymentData?.EmployeeId;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(SupplierPaymentData?.SupplierId)))
                {
                    DDSupplier.SelectedValue = SupplierPaymentData?.SupplierId;
                }

                txtId.Text = SupplierPaymentData.Id.ToString();
            }

        }
        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Text)
            {
                case "Discription":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Amount":
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
                case "txtDiscription":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Discription";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtAmount":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Amount";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                

            }
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
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
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
            if (Validate())
            {
                if (txtId.Text != "" && txtId.Text != "0")
                {
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                    {
                        SupplierPayment sp = Db.SupplierPayment.Get(Convert.ToInt32(txtId.Text));
                        sp.Amount = Convert.ToInt32(txtAmount.Text);
                        sp.Discription = txtDiscription.Text;
                        sp.TransactionDate = Convert.ToDateTime(TransactionDate.Text);
                        sp.EmployeeId = Convert.ToInt32(DDPayedBy.SelectedValue);
                        sp.SupplierId = Convert.ToInt32(DDSupplier.SelectedValue);
                        Db.SupplierPayment.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Your Record Updated Succesfully", "Message", "Ok");
                        RefreshPage();
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
                    SupplierPayment sp = new SupplierPayment();
                    sp.Discription = txtDiscription.Text;
                    sp.Amount = Convert.ToInt32(txtAmount.Text);
                    sp.EmployeeId = Convert.ToInt32(DDPayedBy.SelectedValue);
                    sp.SupplierId = Convert.ToInt32(DDSupplier.SelectedValue);
                    sp.TransactionDate = Convert.ToDateTime(TransactionDate.SelectedDate);
                    sp.CreatedOn = DateTime.Today;
                    DB.SupplierPayment.Add(sp);
                    DB.SupplierPayment.Save();

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
                    using(UnitOfWork db= new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                    {
                        db.SupplierPayment.Delete(Convert.ToInt32(txtId.Text));
                        db.SupplierPayment.Save();
                        RefreshPage();
                    }
                }
            }

        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtDiscription.Text) || txtDiscription.Text == "Discription")
            {
                EZYPOS.View.MessageBox.ShowCustom("Discription is Required.", "Error", "OK");
                return false;

            }
            if (string.IsNullOrEmpty(txtAmount.Text) || txtAmount.Text == "Amount")
            {
                EZYPOS.View.MessageBox.ShowCustom("Amount is Required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(TransactionDate.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Transaction Date.", "Error", "OK");
                return false;
            }
            if (DDPayedBy.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select User.", "Error", "OK");
                return false;
            }
            if (DDSupplier.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Supplier.", "Error", "OK");
                return false;
            }
            

            return true;
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new SupplierPaymentList());
        }
    }
}
