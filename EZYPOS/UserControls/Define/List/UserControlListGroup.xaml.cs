using DAL.Repository;
using EZYPOS.Helper.Session;
using EZYPOS.UserControls.Define.Crud;
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

namespace EZYPOS.UserControls.Define.List
{
    /// <summary>
    /// Interaction logic for UserControlListGroup.xaml
    /// </summary>
    public partial class UserControlListGroup : UserControl
    {
        List<DAL.DBModel.ProductGroup> myList { get; set; }

        public UserControlListGroup()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                myList = DB.ProductGroup.GetAll().ToList();
                MainGrid.ItemsSource = myList;
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlGroupCrud());
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.ProductGroup.GetAll().ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    // myList = DB.ProductCategory.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }

                MainGrid.ItemsSource = myList;
            }

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
               

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                {

                    if (t.Name == "GridName")
                    {
                        myList = DB.ProductGroup.GetAll().Where(x => x.GroupName.ToUpper().StartsWith(filter.ToUpper())).ToList();
                    }
                    MainGrid.ItemsSource = myList;


                }
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBModel.ProductGroup ProductGroup = (DAL.DBModel.ProductGroup)MainGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlGroupCrud(ProductGroup));
        }
    }
}
