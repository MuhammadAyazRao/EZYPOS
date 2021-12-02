using Common.Session;
using DAL.Repository;
using EZYPOS.DBModels;
using EZYPOS.DTO;
using EZYPOS.Helper;
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
    /// Interaction logic for UserControlListEmployee.xaml
    /// </summary>
    public partial class UserControlListEmployee : UserControl
    {
        List<EmployeeDTO> myList { get; set; }
        Pager<EmployeeDTO> Pager = new Helper.Pager<EmployeeDTO>();
        public UserControlListEmployee()
        {
            InitializeComponent(); 
            Refresh();
        }

        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                 myList = DB.Employee.GetAll().Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation.CityName== null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress,Salary=x.Salary,Role=x.RoleNavigation.Name==null?null:x.RoleNavigation.Name,Cnic=x.Cnic }).ToList();
                ResetPaging(myList);
            }
        }

       
        private async  void Add_Click(object sender, RoutedEventArgs e)
        {
                ActiveSession.CloseDisplayuserControlMethod(new UserControlEmployeeCrud());  
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.Employee.GetAll().Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = DB.Employee.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList();
                }

                ResetPaging(myList);
               
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
                    if (filter == "")
                    {
                        myList = DB.Employee.GetAll().Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList();
                       
                    }
                    else
                    {
                        
                        {
                           
                            if (t.Name == "GridName")
                            {
                               myList= DB.Employee.GetAll().Where(x=>x.UserName.ToUpper().StartsWith(filter.ToUpper())).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList(); ;
                            }
                            if (t.Name == "GridCity")
                            {
                                myList = DB.Employee.GetAll().Where(x => x.CityNavigation.CityName.ToUpper().StartsWith(filter.ToUpper())).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList(); ;


                            }
                            if (t.Name == "GridAdress")
                            {
                                myList = DB.Employee.GetAll().Where(x => x.Adress.ToUpper().StartsWith(filter.ToUpper())).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList(); ;


                            }
                            if (t.Name == "GridRole")
                            {
                                myList = DB.Employee.GetAll().Where(x => x.RoleNavigation.Name.ToUpper().StartsWith(filter.ToUpper())).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList(); ;


                            }
                            if (t.Name == "GridSalary")
                            {
                                myList = DB.Employee.GetAll().Where(x => x.Salary.ToString().ToUpper().StartsWith(filter.ToUpper())).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList(); ;


                            }
                            if (t.Name == "GridPhone")
                            {
                                myList = DB.Employee.GetAll().Where(x => x.Phone.ToString().ToUpper().StartsWith(filter.ToUpper())).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList(); ;

                            }
                            if (t.Name == "GridCnic")
                            {
                                myList = DB.Employee.GetAll().Where(x => x.Cnic.ToUpper().StartsWith(filter.ToUpper())).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList(); ;

                            }
                           



                        };
                    }
                    ResetPaging(myList);
                }
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.EmployeeDTO EmployeeDTO = (EZYPOS.DTO.EmployeeDTO)EmployeeGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlEmployeeCrud(EmployeeDTO));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        #region Pagination

        private void ResetPaging(List<EmployeeDTO> ListTopagenate)
        {
            EmployeeGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            EmployeeGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = Pager.Previous(myList);
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
            EmployeeGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

       
        #endregion
    }
}
