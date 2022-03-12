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
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.UserControls.Define.List;

namespace EZYPOS.UserControls.Define.Crud
{
    /// <summary>
    /// Interaction logic for UserControlExpenseTransactionCrud.xaml
    /// </summary>
    public partial class UserControlExpenseTransactionCrud : UserControl
    {
        public UserControlExpenseTransactionCrud(ExpenseTransactionDTO exp = null)
        {
            InitializeComponent();
            RefreshPage();
            if (exp != null)
            { InitializePage(exp); }

        }
        void InitializePage(ExpenseTransactionDTO exp)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                var expData = uw.expt.GetAll().Where(x => x.Id == exp.Id ).FirstOrDefault();
                if (!string.IsNullOrEmpty(expData?.Discription))
                {
                    txtDescription.Text = expData?.Discription;
                    txtDescription.Foreground = Brushes.Black;
                    txtAmount.Text = Convert.ToString(expData?.Amount);
                    txtAmount.Foreground = Brushes.Black;
                    ddEType.SelectedValue = expData?.ExpenceType;
                    TransactionDate.Text = Convert.ToString(expData?.ExpenceDate);
                }
                txtId.Text = expData.Id.ToString();
            }
        }
        void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;
            TransactionDate.SelectedDate = DateTime.Today;
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                ddEType.ItemsSource = uw.ExpenceType.GetAll().ToList();
                ddEmployee.ItemsSource = uw.Employee.GetAll().ToList();
                ddEmployee.SelectedValue = ActiveSession.ActiveUser;
            }
            txtDescription.Text = "";
            txtAmount.Text = "";
            txtId.Text = "";
        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || txtDescription.Text == "Description")
            {
                EZYPOS.View.MessageBox.ShowCustom("Description is Required.", "Error", "OK");
                return false;

            }
            if (string.IsNullOrEmpty(txtAmount.Text) || txtAmount.Text == "Amount")
            {
                EZYPOS.View.MessageBox.ShowCustom("Amount is Required.", "Error", "OK");
                return false;
            }
            
            if (ddEType.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select Expense Type.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(TransactionDate.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Transaction Date is Required", "Error", "Ok");
                return false;
            }

            return true;

        }

        private void ddEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Text)
            {
                case "Description":
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
                case "txtDescription":
                    if (txtDescription.Text == "")
                    {
                        tb.Text = "Description";
                        tb.Foreground = Brushes.Gray;
                        
                    }
                    break;

                case "txtAmount":
                    if (txtAmount.Text == "")
                    {
                        tb.Text = "Amount";
                        tb.Foreground = Brushes.Gray;

                    }
                    break;
                
            }
        }

        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
                {
                    var ex = uw.expt.GetAll().Where(x => x.Id == Convert.ToInt32(txtId.Text)).FirstOrDefault();
                    ex.Discription = txtDescription.Text;
                    ex.Amount = Convert.ToDecimal(txtAmount.Text);
                    ex.ExpenceType = Convert.ToInt32(ddEType.SelectedValue);
                    ex.ExpenceDate = Convert.ToDateTime(TransactionDate.Text);
                    uw.expt.Save();
                    EZYPOS.View.MessageBox.ShowCustom("Your Record Updated Succesfully", "Message", "Ok");
                    RefreshPage();

                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bool isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Alert", "Do You Want to Delete this Record", "Yes", "NO");
            if (isconfirm)
            {
                using(UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
                {
                    uw.expt.Delete(Convert.ToInt32(txtId.Text));
                    uw.expt.Save();
                    EZYPOS.View.MessageBox.ShowCustom("Your Record Deleted Sucessfully", "Message", "Ok");
                    RefreshPage();
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
                {
                    ExpenceTransaction expt = new ExpenceTransaction();
                    expt.Discription = txtDescription.Text;
                    expt.Amount = Convert.ToDecimal(txtAmount.Text);
                    expt.ExpenceType = Convert.ToInt32(ddEType.SelectedValue);
                    expt.EmployeeId = Convert.ToInt32(ddEmployee.SelectedValue);
                    expt.ExpenceDate = Convert.ToDateTime(TransactionDate.Text);
                    uw.expt.Add(expt);
                    uw.expt.Save();
                }
                EZYPOS.View.MessageBox.ShowCustom("Your Record Saved Succesfully", "Message", "Ok");
                RefreshPage();
            }
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListExpenseTransaction());
        }
    }
}
