using Common.Session;
using DAL.DBMODEL;
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
        List<DAL.DBMODEL.ProductCategory> myList { get; set; }
        Pager<DAL.DBMODEL.ProductCategory> Pager = new Helper.Pager<DAL.DBMODEL.ProductCategory>();
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
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.ProductCategory.GetAll().ToList();
                ResetPaging(myList);
            }
        }

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{

        //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
        //    {
        //        if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
        //        {
        //            myList = DB.ProductCategory.GetAll().ToList();
        //        }
        //        else
        //        {
        //            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
        //            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
        //           // myList = DB.ProductCategory.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
        //        }

        //        CategoryGrid.ItemsSource = myList;
        //    }

        //}

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(CategoryGrid.ItemsSource);

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        myList = DB.ProductCategory.GetAll().ToList();   
                    }
                    else
                    {
                        if (t.Name == "GridName")
                        {
                            myList = DB.ProductCategory.GetAll().Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                    }
                    ResetPaging(myList);
                }
            }
        }

        private void ResetPaging(List<DAL.DBMODEL.ProductCategory> ListTopagenate)
        {
            CategoryGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CategoryGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CategoryGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void First_Click(object sender, RoutedEventArgs e)
        {
            CategoryGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CategoryGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBMODEL.ProductCategory ProductCategory = (DAL.DBMODEL.ProductCategory)CategoryGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCategoryCrud(ProductCategory));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBMODEL.ProductCategory ProductCategory = (DAL.DBMODEL.ProductCategory)CategoryGrid.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This Record?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    try
                    {
                        DB.ProductCategory.Delete(ProductCategory.Id);
                        DB.ProductCategory.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                        Refresh();
                    }
                    catch
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Category Can't be Deleted because its being used", "Status", "OK");
                    }

                }
            }
        }
    }
}
