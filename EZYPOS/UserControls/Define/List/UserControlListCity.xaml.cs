using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
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
    /// Interaction logic for UserControlListCity.xaml
    /// </summary>
    public partial class UserControlListCity : UserControl
    {
        List<DAL.DBMODEL.City> myList { get; set; }
        Pager<DAL.DBMODEL.City> Pager = new Helper.Pager<DAL.DBMODEL.City>();
        public UserControlListCity()
        {
            InitializeComponent();
            Refresh();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCityCrud());
        }
        private void ResetPaging(List<DAL.DBMODEL.City> ListTopagenate)
        {
            CityGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
        //    {
        //        List<DAL.DBMODEL.City> myList;
        //        if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
        //        {
        //            myList = DB.City.GetAll().ToList();
        //        }
        //        else
        //        {
        //            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
        //            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
        //            myList = DB.City.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
        //        }

        //        CityGrid.ItemsSource = myList;
        //    }
        //}

        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.City.GetAll().ToList();
                ResetPaging(myList);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBMODEL.City City = (DAL.DBMODEL.City)CityGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCityCrud(City));
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
                        myList = DB.City.GetAll().ToList();
                    }
                    else
                    {
                        if (t.Name == "GridName")
                        {
                            myList = DB.City.GetAll().Where(x => x.CityName.ToUpper().StartsWith(filter.ToUpper())).ToList();
                        }
                    }
                    ResetPaging(myList);
                }
            }
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CityGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void First_Click(object sender, RoutedEventArgs e)
        {
            CityGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CityGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            CityGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBMODEL.City City = (DAL.DBMODEL.City)CityGrid.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This City?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    try
                    {
                        DB.City.Delete(City.Id);
                        DB.City.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                        Refresh();
                    }
                    catch
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Selected City Can't be Deleted", "Status", "OK");
                    }

                }
            }
        }
    }
}
