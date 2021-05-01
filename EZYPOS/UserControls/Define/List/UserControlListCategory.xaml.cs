using Common.Session;
using DAL.Repository;
using EZYPOS.Helper;
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
    /// Interaction logic for UserControlListCategory.xaml
    /// </summary>
    public partial class UserControlListCategory : UserControl
    {
        List<DAL.DBModel.ProductCategory> myList { get; set; }
        Pager<DAL.DBModel.ProductCategory> Pager = new Helper.Pager<DAL.DBModel.ProductCategory>();
        public UserControlListCategory()
        {
            InitializeComponent();
            Refresh();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {            
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCategoryCrud());
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                myList = DB.ProductCategory.GetAll().ToList();
                CategoryGrid.ItemsSource = myList;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.ProductCategory.GetAll().ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                   // myList = DB.ProductCategory.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }

                CategoryGrid.ItemsSource = myList;
            }

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(CategoryGrid.ItemsSource);

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                {

                    if (t.Name == "GridName")
                    {
                        myList = DB.ProductCategory.GetAll().Where(x => x.Name.ToUpper().StartsWith(filter.ToUpper())).ToList();
                    }

                    CategoryGrid.ItemsSource = myList;


                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBModel.ProductCategory ProductCategory = (DAL.DBModel.ProductCategory)CategoryGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCategoryCrud(ProductCategory));
        }
    }
}
