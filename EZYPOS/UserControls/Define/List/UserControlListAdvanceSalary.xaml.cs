using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.UserControls.Define.Crud;
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

namespace EZYPOS.UserControls.Define.List
{
    /// <summary>
    /// Interaction logic for UserControlListAdvanceSalary.xaml
    /// </summary>
    public partial class UserControlListAdvanceSalary : UserControl
    {
        List<AdvanceSalaryDTO> myList { get; set; }
        Pager<AdvanceSalaryDTO> Pager = new Helper.Pager<AdvanceSalaryDTO>();
        public UserControlListAdvanceSalary()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.AdvanceSalary.GetAll().Select(x => new AdvanceSalaryDTO { Id = x.Id, Employee = x.Employee == null ? null : x.Employee.UserName, PayedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, Date = x.Date, Month = Month.GetMonthName(Convert.ToInt32(x.Month)), Amount = x.Amount }).ToList();
                ResetPaging(myList);
            }
        }


        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlAdvanceSalaryCrud());
        }

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
        //    {
        //        if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
        //        {
        //            myList = DB.Employee.GetAll().Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList();
        //        }
        //        else
        //        {
        //            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
        //            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
        //            myList = DB.Employee.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList();
        //        }

        //        ResetPaging(myList);

        //    }
        //}

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        Refresh();
                    }
                    else
                    {
                        myList = DB.AdvanceSalary.GetAll().Select(x => new AdvanceSalaryDTO { Id = x.Id, Employee = x.Employee == null ? null : x.Employee.UserName, PayedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, Date = x.Date, Month = Month.GetMonthName(Convert.ToInt32(x.Month)), Amount = x.Amount }).ToList();
                        if (t.Name == "GridEmployee")
                        {
                            myList = myList.Where(x => x.Employee.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridPayedBy")
                        {
                            myList = myList.Where(x => x.PayedBy.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridDate")
                        {
                            myList = myList.Where(x => x.Date.ToString().Contains(filter)).ToList();
                        }
                        if (t.Name == "GridMonth")
                        {
                            myList = myList.Where(x => x.Month.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridAmount")
                        {
                            myList = myList.Where(x => x.Amount.ToString().Contains(filter)).ToList();
                        }

                        ResetPaging(myList);
                    }
                    
                }
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.AdvanceSalaryDTO AdvanceSalary = (EZYPOS.DTO.AdvanceSalaryDTO)AdvanceSalaryGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlAdvanceSalaryCrud(AdvanceSalary));
        }

        #region Pagination

        private void ResetPaging(List<AdvanceSalaryDTO> ListTopagenate)
        {
            AdvanceSalaryGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            AdvanceSalaryGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            AdvanceSalaryGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)  //I couldn't get this function to update in place (if the grid showed 20 and I selected 100 it would jump to 200)
        {                                                                                          //So instead I had it call the First function and that does an acceptable job.
                                                                                                   // numberOfRecPerPage = Convert.ToInt32(NumberOfRecords.SelectedItem);
                                                                                                   //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            AdvanceSalaryGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            AdvanceSalaryGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        #endregion
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.AdvanceSalaryDTO AdvanceSalary = (EZYPOS.DTO.AdvanceSalaryDTO)AdvanceSalaryGrid.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This Record?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    try
                    {
                        DB.AdvanceSalary.Delete(AdvanceSalary.Id);
                        DB.AdvanceSalary.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deleted Successfully", "Status", "OK");
                        Refresh();
                    }
                    catch
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Selected Record Can't be Deleted", "Status", "OK");
                    }

                }
            }
        }
    }
}
