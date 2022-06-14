using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
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

namespace EZYPOS.UserControls.Utility
{
    /// <summary>
    /// Interaction logic for UserControlUserPages.xaml
    /// </summary>
    public partial class UserControlUserPages : UserControl
    {
        List<UserAccessDTO> AllPages = new List<UserAccessDTO>();
        public UserControlUserPages()
        {
            InitializeComponent();                        
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                var EmployeeList = DB.Employee.GetAll().Select(x => new { Name = x.UserName, Id = x.Id }).ToList();                
                ddEmployee.ItemsSource = EmployeeList;
                ddEmployee.SelectedValue = null;
            }
        }
        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            //GetSelected();
            UserAccessDTO obj = CityGrid.SelectedItem as UserAccessDTO;
            GetSelected();
        }

        private void GetSelected()
        {


            foreach (var item in CityGrid.ItemsSource)
            {
                //if (((CheckBox)StatusIdColumn.GetCellContent(item)).IsChecked == true)
                //{
                //    selectedDiseases.Add(item);
                //}
            }

        }

        private void ddEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ddEmployee.SelectedValue != null)
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    var AssignedPages = DB.UserPage.GetAll().Where(x => x.UserId == Convert.ToInt16(ddEmployee.SelectedValue)).Select(x => x.PageId).ToArray();
                    AllPages = DB.Pages.GetAll().ToList().Select(x => new UserAccessDTO { IsAssigned = AssignedPages.Contains(x.Id), Id = x.Id, PageName = x.PageName }).ToList();
                    CityGrid.ItemsSource = AllPages;
                }

            }
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            CityGrid.ItemsSource=null;
            AllPages.ForEach(x => x.IsAssigned = true);
            CityGrid.ItemsSource = AllPages;
        }

        private void btnUnselectAll_Click(object sender, RoutedEventArgs e)
        {
            CityGrid.ItemsSource = null;
            AllPages.ForEach(x => x.IsAssigned = false);
            CityGrid.ItemsSource = AllPages;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do You Want to Save", "Yes", "No");
            if (isconfirm)
            {
                if (ddEmployee.SelectedValue != null)
                {
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        var AllAssignedpages = DB.UserPage.GetAll().Where(x => x.UserId == Convert.ToInt16(ddEmployee.SelectedValue)).ToList();
                        DB.UserPage.RemoveRange(AllAssignedpages);
                        var UpdatedPages = AllPages.Where(x => x.IsAssigned == true).Select(x => new UserPage { PageId = x.Id, UserId = Convert.ToInt16(ddEmployee.SelectedValue) });
                        DB.UserPage.AddRange(UpdatedPages);

                    }
                }
            } 
        }
    }  
}
