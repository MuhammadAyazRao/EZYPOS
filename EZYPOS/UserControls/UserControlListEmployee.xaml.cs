using EZYPOS.DBModels;
using EZYPOS.DTO;
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
        public UserControlListEmployee( bool Ismenu)
        {
            InitializeComponent();
            if (Ismenu)
            {
                ActiveSession.RefreshEmployeeList += Refresh;
            }           
            Refresh();
        }

        private void Refresh(object sender = null)
        {
            using (EPOSDBContext DB = new EPOSDBContext())
            {
                var EmployeeData = DB.Emplyees.Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress,Salary=x.Salary,Role=x.RoleNavigation==null?null:x.RoleNavigation.Name,Cnic=x.Cnic }).ToList();
                EmployeeGrid.ItemsSource = EmployeeData;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlEmployeeCrud());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<EmployeeDTO> EmployeeList;
            using (EPOSDBContext DB = new EPOSDBContext())
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    EmployeeList = DB.Emplyees.Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    EmployeeList = DB.Emplyees.Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).Select(x => new EmployeeDTO { Id = x.Id, Name = x.UserName, City = x.CityNavigation == null ? null : x.CityNavigation.CityName, Phone = x.Phone, Adress = x.Adress, Salary = x.Salary, Role = x.RoleNavigation == null ? null : x.RoleNavigation.Name, Cnic = x.Cnic }).ToList();
                }

                EmployeeGrid.ItemsSource = EmployeeList;
            }
        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(EmployeeGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        EZYPOS.DTO.EmployeeDTO List = o as EZYPOS.DTO.EmployeeDTO;

                        if (t.Name == "GridName")
                        {
                            return List.Name.ToUpper().StartsWith(filter.ToUpper());                           
                        }                        
                        if (t.Name == "GridCity")
                        {
                            return List.City.ToUpper().StartsWith(filter.ToUpper());
                           
                        }
                        if (t.Name == "GridAdress")
                        {
                            return List.Adress.ToUpper().StartsWith(filter.ToUpper());
                            
                        }
                        if (t.Name == "GridRole")
                        {
                            return List.Role.ToUpper().StartsWith(filter.ToUpper());
                            
                        }
                        if (t.Name == "GridSalary")
                        {
                            return List.Salary.ToString().ToUpper().StartsWith(filter.ToUpper());

                        }
                        if (t.Name == "GridPhone")
                        {
                            return List.Phone.ToUpper().StartsWith(filter.ToUpper());
                        }
                        if (t.Name == "GridCnic")
                        {
                            return List.Cnic.ToUpper().StartsWith(filter.ToUpper());
                        }
                        else
                        {
                            return true;
                        }
                        


                    };
                }
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.EmployeeDTO EmployeeDTO = (EZYPOS.DTO.EmployeeDTO)EmployeeGrid.SelectedItem;
            ActiveSession.NavigateToSwitchScreen(new UserControlEmployeeCrud(EmployeeDTO));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }
    }
}
