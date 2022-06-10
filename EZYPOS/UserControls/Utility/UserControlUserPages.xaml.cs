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
        public UserControlUserPages()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var myList = DB.City.GetAll().ToList().Select(x=>new UserAccessDTO { IsAssigned=true,Id=x.Id.ToString(),PageName=x.CityName }).ToList();
                CityGrid.ItemsSource = myList;
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
    }
   
}
