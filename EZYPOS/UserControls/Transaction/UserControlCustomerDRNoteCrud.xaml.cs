using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.UserControls.Transaction.Lists;
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
    /// Interaction logic for UserControlCustomerDRNoteCrud.xaml
    /// </summary>
    public partial class UserControlCustomerDRNoteCrud : UserControl
    {
        public UserControlCustomerDRNoteCrud(CustomerDRNoteDTO Sp = null)
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
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DDCustomer.ItemsSource = Db.Customers.GetAll().ToList();
                DDReceivedBy.ItemsSource = Db.Employee.GetAll().Select(x=> new {Name = x.UserName, Id = x.Id }).ToList();
            }
            txtDiscription.Text = "";
            txtAmount.Text = "";
            txtId.Text = "";
            DDCustomer.SelectedValue = null;
            DDReceivedBy.SelectedValue = null;
            TransactionDate.SelectedDate = DateTime.Today;
        }
        private void InitializePage(CustomerDRNoteDTO Sp)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var CustomerDRData = Db.CustomerDRNote.Get(Sp.Id);

                if (!string.IsNullOrEmpty(Convert.ToString(CustomerDRData?.ReceiptAmount)))
                {
                    txtAmount.Text = Convert.ToString(CustomerDRData?.ReceiptAmount);
                    txtAmount.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(CustomerDRData?.Discription))
                {
                    txtDiscription.Text = CustomerDRData?.Discription;
                    txtDiscription.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(CustomerDRData?.TransactionDate)))
                {
                    TransactionDate.Text = Convert.ToString(CustomerDRData?.TransactionDate);

                }
                if (!string.IsNullOrEmpty(Convert.ToString(CustomerDRData?.ReceivedBy)))
                {
                    DDReceivedBy.SelectedValue = CustomerDRData?.ReceivedBy;
                }
                if (!string.IsNullOrEmpty(Convert.ToString(CustomerDRData?.CustomerId)))
                {
                    DDCustomer.SelectedValue = CustomerDRData?.CustomerId;
                }
                

                txtId.Text = CustomerDRData.Id.ToString();
            }

        }
        private void NumberDecimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
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
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Update Record?", "Yes", "No");
            if (Isconfirm)
            {
                if (Validate())
                {
                    if (txtId.Text != "" && txtId.Text != "0")
                    {
                        if (DeleteReceipt())
                        {
                            SaveReceipt();
                            EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
                            RefreshPage();
                        }


                    }
                }
            }

        }

        private bool DeleteReceipt()
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    db.CustomerLead.Delete(db.CustomerLead.GetAll().Where(x => x.TransactionType == Common.InvoiceType.CustomerDrNote && x.TransactionId == Convert.ToInt32(txtId.Text)).FirstOrDefault().Id);
                    db.CustomerDRNote.Delete(Convert.ToInt32(txtId.Text));
                    db.CustomerDRNote.Save();
                    return true;

                }
            }
            catch (Exception exp)
            {


                EZYPOS.View.MessageBox.ShowCustom("Unable to Update Record", "Status", "OK");
                return false;
            }
        }
        private void SaveReceipt()
        {
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                CustomerDrnote sp = new CustomerDrnote();
                sp.Discription = txtDiscription.Text;
                sp.ReceiptAmount = txtAmount.Text;
                sp.ReceivedBy = Convert.ToInt32(DDReceivedBy.SelectedValue);
                sp.CustomerId = Convert.ToInt32(DDCustomer.SelectedValue);
                sp.TransactionDate = Convert.ToDateTime(TransactionDate.Text);
                sp.CreatedOn = DateTime.Now;
                DB.CustomerDRNote.Add(sp);
                DB.CustomerDRNote.Save();

                //Ledger


                CustomerLead CustomerLedCR = new CustomerLead();
                CustomerLedCR.Dr = Convert.ToInt32(txtAmount.Text);
                CustomerLedCR.TransactionDate = Convert.ToDateTime(TransactionDate.Text);
                CustomerLedCR.TransactionId = sp.Id;
                CustomerLedCR.TransactionType = Common.InvoiceType.CustomerDrNote;
                if (string.IsNullOrEmpty(txtDiscription.Text))
                {
                    CustomerLedCR.TransactionDetail = "Customer Credit Balance settlement Till Date: " + TransactionDate.SelectedDate?.ToString("dd/MM/yyyy") + " against DR Invoice Number # " + sp.Id;
                }
                else
                {
                    CustomerLedCR.TransactionDetail = txtDiscription.Text + " against DR Invoice Number # " + sp.Id;
                }
                CustomerLedCR.CustomerId = Convert.ToInt32(DDCustomer.SelectedValue);
                DB.CustomerLead.Add(CustomerLedCR);

            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Save Record?", "Yes", "No");
            if (Isconfirm)
            {
                if (Validate())
                {
                    SaveReceipt();
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
                    if (DeleteReceipt())
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Record Deleted Successfully", "Status", "OK");
                        RefreshPage();
                    }
                }
            }

        }
        private void List_Click(object sender, RoutedEventArgs e)
        {
            UserControlCustomerDRNoteList CustomerDRNoteList = new UserControlCustomerDRNoteList();
            ActiveSession.CloseDisplayuserControlMethod(CustomerDRNoteList);
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
            if (TransactionDate.SelectedDate == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Transaction Date.", "Error", "OK");
                return false;
            }
            if (DDReceivedBy.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select User.", "Error", "OK");
                return false;
            }
            if (DDCustomer.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Customer.", "Error", "OK");
                return false;
            }


            return true;
        }

        
    }
}