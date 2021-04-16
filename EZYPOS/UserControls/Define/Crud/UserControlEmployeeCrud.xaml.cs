using DAL.Repository;
using EZYPOS.DBModels;
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

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlEmployeeCrud.xaml
    /// </summary>
    public partial class UserControlEmployeeCrud : UserControl
    {
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
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                var cities = Db.City.GetAll().ToList();
                ddCity.ItemsSource = cities;
                var Roles = Db.UserRole.GetAll().ToList();
                ddRole.ItemsSource = Roles;
            }
            txtFName.Text = "Name";
            txtFName.Foreground = Brushes.Gray;
            txtPhone.Text = "Phone";
            txtPhone.Foreground = Brushes.Gray;
            txtAddress.Text = "Address";
            txtAddress.Foreground = Brushes.Gray;
            txtSalary.Text = "Salary";  
            txtSalary.Foreground= Brushes.Gray;
            txtCnic.Text = "CNIC";
            txtCnic.Foreground = Brushes.Gray;
            ddCity.SelectedValue = null;
            ddRole.SelectedValue = null;
            JoiningDate.Text ="";
            txtId.Text = "";
            SetImage(Environment.CurrentDirectory + @"\Assets\EmployeeImages\No_Image.jpg");
            //ActiveSession.NavigateToRefreshEmployeeList("");
        }

        private void InitializePage(EmployeeDTO Employee)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (EPOSDBContext Db = new EPOSDBContext())
            {
                var EmployeeData = Db.Emplyees.Where(x => x.Id == Employee.Id).FirstOrDefault();

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
                txtId.Text = EmployeeData.Id.ToString();
            }

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlListSupplier());
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirmed = EZYPOS.View.MessageYesNo.ShowCustom("Refresh", "Do you want to refresh page?", "Yes", "No");
            if (Isconfirmed)
            { RefreshPage(); }
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
                case "Address":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Salary":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "CNIC":
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
                case "txtSalary":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Salary";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;                    
                case "txtCnic":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "CNIC";
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
                    using (EPOSDBContext DB = new EPOSDBContext())
                    {
                        var UpdateEmployee = DB.Emplyees.Where(x => x.Id == Id).FirstOrDefault();
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
                            if (!string.IsNullOrEmpty(UserImage.Source?.ToString()))
                            {
                                UpdateEmployee.Image = UserImage.Source?.ToString();
                            }
                            DB.SaveChanges();
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

            return true;

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Save Record?", "Yes", "No");
            if (Isconfirm)
            {
                if (Validate())
                {
                    using (EPOSDBContext DB = new EPOSDBContext())
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
                        if (!string.IsNullOrEmpty(UserImage.Source?.ToString()))
                        {
                            AddEmployee.Image = UserImage.Source?.ToString();
                        }
                        DB.Emplyees.Add(AddEmployee);
                        DB.SaveChanges();
                        EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
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
                    int Id = Convert.ToInt32(txtId.Text);
                    using (EPOSDBContext DB = new EPOSDBContext())
                    {
                        var Employee = DB.Emplyees.Where(x => x.Id == Id).FirstOrDefault();
                        DB.Remove(Employee);
                        DB.SaveChanges();
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
            //if (File.Exists(ImagePath))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath);
                bitmap.EndInit();
                UserImage.Source = bitmap;
                ImageSelector.Content = UserName;
            }
        }
    }
}
