using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.DTO.ReportsDTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlAdvanceSalaryReport.xaml
    /// </summary>
    public partial class UserControlAdvanceSalaryReport : UserControl
    {
        List<AdvanceSalaryReportDTO> myList = new List<AdvanceSalaryReportDTO>();
        Pager<AdvanceSalaryReportDTO> Pager = new Helper.Pager<AdvanceSalaryReportDTO>();
        public UserControlAdvanceSalaryReport()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                var EmployeeList = DB.Employee.GetAll().Select(x => new { Name = x.UserName, Id = x.Id }).ToList();
                EmployeeList.Insert(0, new { Name = "All", Id = 0 });
                ddEmployee.ItemsSource = EmployeeList;
                ddEmployee.SelectedIndex = 0;
                var MonthList = Month.GetMonths().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                MonthList.Insert(0, new { Name = "All", Id = 0 });
                ddMonth.ItemsSource = MonthList;
                ddMonth.SelectedIndex = 0;
                List<Months> StatusList = new List<Months>();
                StatusList.Add(new Months { Name = "All", Id = 0 });
                StatusList.Add(new Months { Name = "Advance", Id = 1 });
                StatusList.Add(new Months { Name = "Disbursment", Id = 2 });
                ddSalaryStatus.ItemsSource = StatusList.Select(x=> new { Name = x.Name, Id = x.Id });
                ddSalaryStatus.SelectedIndex = 0;
            }
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;
            Refresh();
        }


        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    var Items = DB.AdvanceSalary.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                    if(Convert.ToInt32(ddEmployee.SelectedValue) != 0)
                    {
                        Items = Items.Where(x => x.EmployeeId == Convert.ToInt32(ddEmployee.SelectedValue)).ToList();
                    }
                    if (Convert.ToInt32(ddMonth.SelectedValue) != 0)
                    {
                        Items = Items.Where(x => x.Month == Convert.ToInt32(ddMonth.SelectedValue)).ToList();
                    }
                    if (Convert.ToInt32(ddSalaryStatus.SelectedValue) != 0)
                    {
                        if(Convert.ToInt32(ddSalaryStatus.SelectedValue) == 1)
                        {
                            Items = Items.Where(x => x.IsAdvance == true).ToList();
                        }
                        else
                        {
                            Items = Items.Where(x => x.IsAdvance == false).ToList();
                        }
                        
                    }
                    string SalaryStatus = "";
                    string EmployeeName = "";
                    string PayedByName = "";
                    myList.Clear();
                    foreach (var item in Items)
                    {
                        if(item.IsAdvance == true)
                        {
                            SalaryStatus = "Advance";
                        }
                        else
                        {
                            SalaryStatus = "Disbursment";
                        }
                        EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                        PayedByName = DB.Employee.Get(Convert.ToInt32(item.PayedBy)).UserName;
                        myList.Add(new AdvanceSalaryReportDTO { Employee = EmployeeName, PayedBy = PayedByName, Date = item.Date?.ToString("dd/MM/yyyy"), Month = Month.GetMonthName(Convert.ToInt32(item.Month)), Amount = item.Amount?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")), Status = SalaryStatus });  
                    }
                    ResetPaging(myList);
                }
            }
        }
        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                    if (filter == "")
                    {
                        Refresh();
                    }
                    else
                    {
                        if (t.Name == "GridEmployee")
                        {
                            var Items = DB.AdvanceSalary.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                            if (Convert.ToInt32(ddEmployee.SelectedValue) != 0)
                            {
                                Items = Items.Where(x => x.EmployeeId == Convert.ToInt32(ddEmployee.SelectedValue)).ToList();
                            }
                            if (Convert.ToInt32(ddMonth.SelectedValue) != 0)
                            {
                                Items = Items.Where(x => x.Month == Convert.ToInt32(ddMonth.SelectedValue)).ToList();
                            }
                            if (Convert.ToInt32(ddSalaryStatus.SelectedValue) != 0)
                            {
                                if (Convert.ToInt32(ddSalaryStatus.SelectedValue) == 1)
                                {
                                    Items = Items.Where(x => x.IsAdvance == true).ToList();
                                }
                                else
                                {
                                    Items = Items.Where(x => x.IsAdvance == false).ToList();
                                }

                            }
                            string SalaryStatus = "";
                            string EmployeeName = "";
                            string PayedByName = "";
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                if (item.IsAdvance == true)
                                {
                                    SalaryStatus = "Advance";
                                }
                                else
                                {
                                    SalaryStatus = "Disbursment";
                                }
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                PayedByName = DB.Employee.Get(Convert.ToInt32(item.PayedBy)).UserName;
                                if (EmployeeName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    myList.Add(new AdvanceSalaryReportDTO { Employee = EmployeeName, PayedBy = PayedByName, Date = item.Date?.ToString("dd/MM/yyyy"), Month = Month.GetMonthName(Convert.ToInt32(item.Month)), Amount = item.Amount?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")), Status = SalaryStatus });
                                }
                            }
                        }
                        if (t.Name == "GridPayedBy")
                        {
                            var Items = DB.AdvanceSalary.GetAll().Where(x => x.Date >= Sdate && x.Date <= Edate).ToList();
                            if (Convert.ToInt32(ddEmployee.SelectedValue) != 0)
                            {
                                Items = Items.Where(x => x.EmployeeId == Convert.ToInt32(ddEmployee.SelectedValue)).ToList();
                            }
                            if (Convert.ToInt32(ddMonth.SelectedValue) != 0)
                            {
                                Items = Items.Where(x => x.Month == Convert.ToInt32(ddMonth.SelectedValue)).ToList();
                            }
                            if (Convert.ToInt32(ddSalaryStatus.SelectedValue) != 0)
                            {
                                if (Convert.ToInt32(ddSalaryStatus.SelectedValue) == 1)
                                {
                                    Items = Items.Where(x => x.IsAdvance == true).ToList();
                                }
                                else
                                {
                                    Items = Items.Where(x => x.IsAdvance == false).ToList();
                                }

                            }
                            string SalaryStatus = "";
                            string EmployeeName = "";
                            string PayedByName = "";
                            myList.Clear();
                            foreach (var item in Items)
                            {
                                if (item.IsAdvance == true)
                                {
                                    SalaryStatus = "Advance";
                                }
                                else
                                {
                                    SalaryStatus = "Disbursment";
                                }
                                EmployeeName = DB.Employee.Get(Convert.ToInt32(item.EmployeeId)).UserName;
                                PayedByName = DB.Employee.Get(Convert.ToInt32(item.PayedBy)).UserName;
                                if (PayedByName.ToUpper().Contains(filter.ToUpper()))
                                {
                                    myList.Add(new AdvanceSalaryReportDTO { Employee = EmployeeName, PayedBy = PayedByName, Date = item.Date?.ToString("dd/MM/yyyy"), Month = Month.GetMonthName(Convert.ToInt32(item.Month)), Amount = item.Amount?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")), Status = SalaryStatus });
                                }
                            }
                        }
                        ResetPaging(myList);
                    }

                }
            }

        }


        #region Pagination

        private void ResetPaging(List<AdvanceSalaryReportDTO> ListTopagenate)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            ItemWiseSaleGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            ItemWiseSaleGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.Employee, COLB = x.PayedBy, COLC = x.Date, COLD = x.Month, COLE = x.Status, COLF = x.Amount }).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy") + ", Employee: " + ddEmployee.Text + ", Month: "+ ddMonth.Text;
            ReportPrintHelper.PrintCOL6Report(ref ReportViewer, "Salary Report", "Employee", "Payed By", "Date", "Month", "Status", "Amount", Discription, RptData);

        }


        #endregion

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}