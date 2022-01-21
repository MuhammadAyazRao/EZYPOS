using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.UserControls.Define.List;
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

namespace EZYPOS.UserControls.Define.Crud
{
    /// <summary>
    /// Interaction logic for UserControlAdvanceSalaryCrud.xaml
    /// </summary>
    public partial class UserControlAdvanceSalaryCrud : UserControl
    {
        System.Windows.Threading.DispatcherTimer DDTimer = new System.Windows.Threading.DispatcherTimer();
        public UserControlAdvanceSalaryCrud(AdvanceSalaryDTO AdvanceSalary = null)
        {
            InitializeComponent();
            RefreshPage();
            if (AdvanceSalary != null)
            { InitializePage(AdvanceSalary); }
        }
        
        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var EmployeeList = DB.Employee.GetAll().Select(x => new { Name = x.UserName, Id = x.Id }).ToList();
                ddEmployee.ItemsSource = EmployeeList;
                ddPayedBy.ItemsSource = EmployeeList;
                var Months = Month.GetMonths().Select(x=> new { Name = x.Name , Id = x.Id});
                ddMonth.ItemsSource = Months;

            }
            ddEmployee.SelectedValue = null;
            ddPayedBy.SelectedValue = null;
            ddMonth.SelectedValue = null;
            txtSalary.Text = "Salary";
            txtSalary.Foreground = Brushes.Gray;
            SalaryDate.SelectedDate = DateTime.Today;
            txtId.Text = "";
        }

        private void InitializePage(AdvanceSalaryDTO AdvanceSalary)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                var AdvanceSalaryobj = Db.AdvanceSalary.GetAll().Where(x => x.Id == AdvanceSalary.Id).FirstOrDefault();

                if (AdvanceSalaryobj?.Amount != null)
                {
                    txtSalary.Text = Convert.ToString(AdvanceSalaryobj.Amount);
                    txtSalary.Foreground = Brushes.Black;
                }
                if (AdvanceSalaryobj?.EmployeeId != null)
                {
                    ddEmployee.SelectedValue = AdvanceSalaryobj.EmployeeId;
                   
                }
                if(AdvanceSalaryobj?.PayedBy != null)
                {
                    ddPayedBy.SelectedValue = AdvanceSalaryobj.PayedBy;
                }
                if(AdvanceSalaryobj?.Month != null)
                {
                    ddMonth.SelectedValue = AdvanceSalaryobj.Month;
                }
                if(AdvanceSalaryobj?.Date != null)
                {
                    SalaryDate.SelectedDate = AdvanceSalaryobj.Date;
                }
                txtId.Text = AdvanceSalaryobj.Id.ToString();
            }

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
                case "Salary":
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
                case "txtSalary":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Salary";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                

            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    int? Id = Convert.ToInt32(ddEmployee.SelectedValue);
                    int MonthlySalary = Convert.ToInt32(DB.Employee.Get(Convert.ToInt32(ddEmployee.SelectedValue)).Salary);
                    int AdvSalary = Convert.ToInt32(txtSalary.Text);
                    AdvancedSalary UpdateAdvanceSalary = DB.AdvanceSalary.GetAll().Where(x => x.EmployeeId == Id).FirstOrDefault();
                    if (UpdateAdvanceSalary != null)
                    {
                        if (AdvSalary > MonthlySalary)
                        {
                            bool Isconfirm2 = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Advance Salary Exceeds. Want to Proceed?", "Yes", "No");
                            if (Isconfirm2)
                            {
                                UpdateAdvanceSalary.PayedBy = Convert.ToInt32(ddPayedBy.SelectedValue);
                                UpdateAdvanceSalary.Month = Convert.ToInt32(ddMonth.SelectedValue);
                                UpdateAdvanceSalary.Date = SalaryDate.SelectedDate;
                                UpdateAdvanceSalary.Amount = AdvSalary;
                                DB.AdvanceSalary.Save();
                                EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                                RefreshPage();
                            }
                        }
                        else
                        {
                            UpdateAdvanceSalary.PayedBy = Convert.ToInt32(ddPayedBy.SelectedValue);
                            UpdateAdvanceSalary.Month = Convert.ToInt32(ddMonth.SelectedValue);
                            UpdateAdvanceSalary.Date = SalaryDate.SelectedDate;
                            UpdateAdvanceSalary.Amount = AdvSalary;
                            DB.AdvanceSalary.Save();
                            EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                            RefreshPage();
                        }
                    }
                    
                }
            }
        }
        private bool Validate()
        {
            
            if (ddEmployee.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select an Employee.", "Error", "OK");
                return false;
            }
          
            if (ddPayedBy.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select Payed By.", "Error", "OK");
                return false;
            }
            if(ddEmployee.SelectedValue.ToString() == ddPayedBy.SelectedValue.ToString())
            {
                EZYPOS.View.MessageBox.ShowCustom("Employee and Payed By could't be Same.", "Error", "OK");
                return false;
            }
            if(txtSalary.Text == "" || txtSalary.Text == "Salary")
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Provide Salary Amount.", "Error", "OK");
                return false;
            }
            if(SalaryDate.SelectedDate == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select Date.", "Error", "OK");
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
                    int? Id = Convert.ToInt32(ddEmployee.SelectedValue);
                    int MonthlySalary = Convert.ToInt32(DB.Employee.Get(Convert.ToInt32(ddEmployee.SelectedValue)).Salary);
                    int AdvSalary = Convert.ToInt32(txtSalary.Text);
                    AdvancedSalary ExistingEmployee = DB.AdvanceSalary.GetAll().Where(x => x.EmployeeId == Id).FirstOrDefault();
                    if(ExistingEmployee != null)
                    {
                        int SalaryTaken = Convert.ToInt32(ExistingEmployee.Amount);
                        bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Already Taken .Want to Proceed?", "Yes", "No");
                        if (Isconfirm)
                        {
                            if (AdvSalary+SalaryTaken > MonthlySalary)
                            {
                                bool Isconfirm2 = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Advance Salary Exceeds. Want to Proceed?", "Yes", "No");
                                if (Isconfirm2)
                                {
                                    ExistingEmployee.PayedBy = Convert.ToInt32(ddPayedBy.SelectedValue);
                                    ExistingEmployee.Month = Convert.ToInt32(ddMonth.SelectedValue);
                                    ExistingEmployee.Date = SalaryDate.SelectedDate;
                                    ExistingEmployee.Amount = AdvSalary + SalaryTaken;
                                    ExistingEmployee.IsAdvance = true;
                                    DB.AdvanceSalary.Save();
                                    EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                                    RefreshPage();
                                }
                            }
                            else
                            {
                                ExistingEmployee.PayedBy = Convert.ToInt32(ddPayedBy.SelectedValue);
                                ExistingEmployee.Month = Convert.ToInt32(ddMonth.SelectedValue);
                                ExistingEmployee.Date = SalaryDate.SelectedDate;
                                ExistingEmployee.Amount = AdvSalary + SalaryTaken;
                                ExistingEmployee.IsAdvance = true;
                                DB.AdvanceSalary.Save();
                                EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                                RefreshPage();
                            }
                        }
                    }
                    else if (AdvSalary > MonthlySalary)
                    {
                        bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Advance Salary Exceeds. Want to Proceed?", "Yes", "No");
                        if (Isconfirm)
                        {
                            AdvancedSalary AddAdvanceSalary = new AdvancedSalary();
                            AddAdvanceSalary.EmployeeId = Convert.ToInt32(ddEmployee.SelectedValue);
                            AddAdvanceSalary.PayedBy = Convert.ToInt32(ddPayedBy.SelectedValue);
                            AddAdvanceSalary.Month = Convert.ToInt32(ddMonth.SelectedValue);
                            AddAdvanceSalary.Date = SalaryDate.SelectedDate;
                            AddAdvanceSalary.Amount = AdvSalary;
                            AddAdvanceSalary.IsAdvance = true;
                            DB.AdvanceSalary.Add(AddAdvanceSalary);
                            DB.AdvanceSalary.Save();
                            EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                            RefreshPage();
                        }
                    }
                    else
                    {
                        AdvancedSalary AddAdvanceSalary = new AdvancedSalary();
                        AddAdvanceSalary.EmployeeId = Convert.ToInt32(ddEmployee.SelectedValue);
                        AddAdvanceSalary.PayedBy = Convert.ToInt32(ddPayedBy.SelectedValue);
                        AddAdvanceSalary.Month = Convert.ToInt32(ddMonth.SelectedValue);
                        AddAdvanceSalary.Date = SalaryDate.SelectedDate;
                        AddAdvanceSalary.Amount = AdvSalary;
                        AddAdvanceSalary.IsAdvance = true;
                        DB.AdvanceSalary.Add(AddAdvanceSalary);
                        DB.AdvanceSalary.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                        RefreshPage();
                    }
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

                        DB.AdvanceSalary.Delete(Convert.ToInt32(txtId.Text));
                        DB.AdvanceSalary.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deleted Successfully", "Status", "OK");
                        RefreshPage();
                    }
                }
            }

        }

        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        
        private void ddCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListAdvanceSalary());
        }
    }
}
