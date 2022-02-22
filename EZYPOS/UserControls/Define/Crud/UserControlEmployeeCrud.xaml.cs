using Common.Session;
using DAL.Repository;
using DAL.DBMODEL;
using EZYPOS.DTO;
using EZYPOS.Helper.Session;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using EZYPOS.Helper;
using Common;

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlEmployeeCrud.xaml
    /// </summary>
    public partial class UserControlEmployeeCrud : UserControl
    {
        System.Windows.Threading.DispatcherTimer DDTimer = new System.Windows.Threading.DispatcherTimer();
        public UserControlEmployeeCrud(EmployeeDTO Employee = null)
        {
            InitializeComponent();
            RefreshPage();
            if (Employee != null)
            { InitializePage(Employee); }
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
                var Roles = Db.UserRole.GetAll().ToList();
                ddRole.ItemsSource = Roles;
                List<TypeOfSalary> StatusList = new List<TypeOfSalary>();
                StatusList.Add(new TypeOfSalary { Name = SalaryMode.Monthly, Id = 1 });
                StatusList.Add(new TypeOfSalary { Name = SalaryMode.Hourly, Id = 2 });
                ddSalaryType.ItemsSource = StatusList.Select(x => new { Name = x.Name, Id = x.Id });
            }
            txtFName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtSalary.Text = "";
            txtCnic.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            ddCity.SelectedValue = null;
            ddRole.SelectedValue = null;
            ddSalaryType.SelectedValue = 1;
            txtId.Text = "";
            ckLogin.IsChecked = false;
            txtUserName.Visibility = Visibility.Collapsed;
            txtPassword.Visibility = Visibility.Collapsed;
            JoiningDate.SelectedDate = DateTime.Today;
            SetImage(Environment.CurrentDirectory + @"\Assets\EmployeeImages\No_Image.jpg");
            //ActiveSession.NavigateToRefreshEmployeeList("");
        }

        private void InitializePage(EmployeeDTO Employee)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                var EmployeeData = Db.Employee.GetAll().Where(x => x.Id == Employee.Id).FirstOrDefault();

                if (!string.IsNullOrEmpty(EmployeeData?.UserName))
                {
                    txtFName.Text = EmployeeData?.UserName;
                    txtFName.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(EmployeeData?.Phone))
                {
                    txtPhone.Text = EmployeeData?.Phone;
                    txtPhone.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(EmployeeData?.Adress))
                {
                    txtAddress.Text = EmployeeData.Adress;
                    txtAddress.Foreground = Brushes.Black;
                }
                if (EmployeeData.Salary!=0)
                {
                    txtSalary.Text = EmployeeData.Salary.ToString();
                    txtSalary.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(EmployeeData?.Cnic))
                {
                    txtCnic.Text = EmployeeData.Cnic;
                    txtCnic.Foreground = Brushes.Black;
                }

                if (EmployeeData?.Createdon!=null)
                {
                    JoiningDate.Text = EmployeeData.Createdon?.ToString("dd/MM/yyyy");                    
                }
                if (EmployeeData?.City != 0)
                {
                    ddCity.SelectedValue = EmployeeData.City;
                }
                if (EmployeeData?.Role != 0)
                {
                    ddRole.SelectedValue = EmployeeData.Role;
                }
                
                if (!string.IsNullOrEmpty(EmployeeData?.Image))
                {
                    SetImage(EmployeeData.Image);
                }
                if (!string.IsNullOrEmpty(EmployeeData?.SalaryType))
                {
                    if(EmployeeData.SalaryType == SalaryMode.Monthly)
                    {
                        ddSalaryType.SelectedValue = 1;
                    }
                    else
                    {
                        ddSalaryType.SelectedValue = 2;
                        if (EmployeeData?.WorkingHours != null)
                        {
                            txtWorkingHours.Text = EmployeeData.WorkingHours.ToString();
                        }
                    }
                    
                }
                if (EmployeeData?.IsLoginAllowed == true)
                {
                    ckLogin.IsChecked = true;
                    txtUserName.Text = EmployeeData?.LoginName;
                    txtPassword.Text = EmployeeData?.Password;
                }
                txtId.Text = EmployeeData.Id.ToString();
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

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (txtId.Text != "" && txtId.Text != "0")
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        var UpdateEmployee = DB.Employee.GetAll().Where(x => x.Id == Id).FirstOrDefault();
                        if (UpdateEmployee != null)
                        {
                            if (!string.IsNullOrEmpty(txtFName.Text))
                            {
                                UpdateEmployee.UserName = txtFName.Text;
                            }
                            if (!string.IsNullOrEmpty(txtPhone.Text))
                            {
                                UpdateEmployee.Phone = txtPhone.Text;
                            }
                            if (!string.IsNullOrEmpty(txtSalary.Text))
                            {
                                UpdateEmployee.Salary =Convert.ToInt32(txtSalary.Text);
                            }
                            if (!string.IsNullOrEmpty(txtAddress.Text))
                            {
                                UpdateEmployee.Adress = txtAddress.Text;
                            }
                            int CityId = Convert.ToInt32(ddCity.SelectedValue);
                            if (CityId != 0)
                            {
                                UpdateEmployee.City = CityId;
                            }
                            int RoleId = Convert.ToInt32(ddRole.SelectedValue);
                            if (RoleId != 0)
                            {
                                UpdateEmployee.Role = RoleId;
                            }
                            if (!string.IsNullOrEmpty(txtCnic.Text))
                            {
                                UpdateEmployee.Cnic = txtCnic.Text;
                            }
                            if (!string.IsNullOrEmpty(JoiningDate.Text))
                            {
                                UpdateEmployee.Createdon = Convert.ToDateTime(JoiningDate.Text);
                            }
                            if (Convert.ToInt32(ddSalaryType.SelectedValue) == 1)
                            {
                                UpdateEmployee.SalaryType = ddSalaryType.Text;
                                UpdateEmployee.WorkingHours = null;
                            }
                            else
                            {
                                UpdateEmployee.SalaryType = ddSalaryType.Text;
                                UpdateEmployee.WorkingHours = Convert.ToDecimal(txtWorkingHours.Text);
                            }
                            if(ckLogin.IsChecked == true)
                            {
                                UpdateEmployee.IsLoginAllowed = true;
                                if (!string.IsNullOrEmpty(txtUserName.Text))
                                {
                                    UpdateEmployee.LoginName = txtUserName.Text;
                                }
                                if (!string.IsNullOrEmpty(txtPassword.Text))
                                {
                                    UpdateEmployee.Password = txtPassword.Text;
                                }
                            }
                            else
                            {
                                UpdateEmployee.IsLoginAllowed = false;
                                UpdateEmployee.LoginName = null;
                                UpdateEmployee.Password = null;
                            }
                            if (!string.IsNullOrEmpty(UserImage.Source?.ToString()))
                            {
                                UpdateEmployee.Image = UserImage.Source?.ToString();
                            }
                            DB.Employee.Save();
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
            //if (!string.IsNullOrEmpty(txtAddress.Text))
            //{
            //    return false;
            //}

            //if (!string.IsNullOrEmpty(txtMobile.Text))
            //{
            //    return false;
            //}
            if (ddCity.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select City.", "Error", "OK");
                return false;
            }
            if (ckLogin.IsChecked == true)
            {
               if(txtUserName.Text == "" || txtPassword.Text =="")
                {
                    EZYPOS.View.MessageBox.ShowCustom("Please Provide UserName and Password.", "Error", "OK");
                    return false;
                }

            }
            if(Convert.ToInt32(ddSalaryType.SelectedValue) == 2)
            {
                if(txtWorkingHours.Text == "")
                {
                    EZYPOS.View.MessageBox.ShowCustom("Please Provide Working Hours.", "Error", "OK");
                    return false;
                }
            }
            return true;

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    Emplyee AddEmployee = new Emplyee();

                    if (!string.IsNullOrEmpty(txtFName.Text))
                    {
                        AddEmployee.UserName = txtFName.Text;
                    }
                    if (!string.IsNullOrEmpty(txtPhone.Text))
                    {
                        AddEmployee.Phone = txtPhone.Text;
                    }
                    if (!string.IsNullOrEmpty(txtSalary.Text))
                    {
                        AddEmployee.Salary = Convert.ToInt32(txtSalary.Text);
                    }
                    if (!string.IsNullOrEmpty(txtAddress.Text))
                    {
                        AddEmployee.Adress = txtAddress.Text;
                    }
                    int CityId = Convert.ToInt32(ddCity.SelectedValue);
                    if (CityId != 0)
                    {
                        AddEmployee.City = CityId;
                    }
                    int RoleId = Convert.ToInt32(ddRole.SelectedValue);
                    if (RoleId != 0)
                    {
                        AddEmployee.Role = RoleId;
                    }
                    if (!string.IsNullOrEmpty(txtCnic.Text))
                    {
                        AddEmployee.Cnic = txtCnic.Text;
                    }
                    if (!string.IsNullOrEmpty(JoiningDate.Text))
                    {
                        AddEmployee.Createdon = Convert.ToDateTime(JoiningDate.Text);
                    }
                    if (Convert.ToInt32(ddSalaryType.SelectedValue) ==1)
                    {
                        AddEmployee.SalaryType = ddSalaryType.Text;
                    }
                    else
                    {
                        AddEmployee.SalaryType = ddSalaryType.Text;
                        AddEmployee.WorkingHours = Convert.ToDecimal(txtWorkingHours.Text);
                    }
                    if(ckLogin.IsChecked == true)
                    {
                        AddEmployee.IsLoginAllowed = true;
                        AddEmployee.LoginName = txtUserName.Text;
                        AddEmployee.Password = txtPassword.Text;
                    }
                    if (!string.IsNullOrEmpty(UserImage.Source?.ToString()))
                    {
                        AddEmployee.Image = UserImage.Source?.ToString();
                    }
                    DB.Employee.Add(AddEmployee);
                    DB.Employee.Save();
                    EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
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
                        
                        DB.Employee.Delete(Convert.ToInt32(txtId.Text));
                        DB.Employee.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
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

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;            
            if (dlg.ShowDialog()==true)
            {
                string selectedFileName = dlg.FileName;                
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                UserImage.Source = bitmap;             
                string imgDirPath = Environment.CurrentDirectory+ @"\Assets\EmployeeImages\";
                string ImgFullPath = imgDirPath + DateTime.Now.ToString("ddMMyyyyhhmmsstt")+".jpg";
                if(Directory.Exists(ImgFullPath))
                {
                    Directory.Delete(ImgFullPath);
                }
                SaveImage(bitmap, ImgFullPath);
                SetImage(ImgFullPath);
            }
        }

        private  void SaveImage(BitmapImage image, string filePath)
        {
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }


        private void SetImage(string ImagePath,string UserName="Employee Image")
        {
            if (File.Exists(ImagePath))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath);
                bitmap.EndInit();
                UserImage.Source = bitmap;
                ImageSelector.Content = UserName;
            }
        }
        DateTime StartTime;
        void TimerReset()
        {
            StartTime = DateTime.Now;
            DDTimer.Interval = new TimeSpan(0, 0, 1);
            DDTimer.Start();
        }
        private void ddCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            //DateTime TimeNow = StartTime.AddMilliseconds(5000);
            //if (TimeNow < DateTime.Now)
            //{ EZYPOS.View.MessageBox.ShowCustom("selection changed" + ddCity.SelectedValue, "City", "Ok"); }
            //TimerReset();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListEmployee());
        }

        private void ddSalaryType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Convert.ToInt32(ddSalaryType.SelectedValue) == 1)
            {
                txtWorkingHours.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtWorkingHours.Visibility = Visibility.Visible;
            }
        }

        private void ckLogin_Checked(object sender, RoutedEventArgs e)
        {
            if(ckLogin.IsChecked == true)
            {
                txtUserName.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Visible;
            }
            else
            {
                txtUserName.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Collapsed;
            }
        }
    }
}
