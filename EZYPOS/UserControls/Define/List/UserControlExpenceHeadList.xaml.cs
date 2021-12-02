using Common.Session;
using DAL.DBModel;
using DAL.Repository;
using EZYPOS.DBModels;
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
    ///  adList.xaml
    /// </summary>
    public partial class UserControlExpenceHeadList : UserControl
    {
        List<DAL.DBMODEL.ExpenceType> myList { get; set; }
        Pager<DAL.DBMODEL.ExpenceType> Pager = new Helper.Pager<DAL.DBMODEL.ExpenceType>();
        public UserControlExpenceHeadList()
        {
            
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.ExpenceType.GetAll().ToList();
                ExpenceHeadGrid.ItemsSource = myList;
                ResetPaging(myList);
            }
        }

        private void AddExpenceHead_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlExpenceHeadCrud());

           // ActiveSession.NavigateToSwitchScreen(new UserControlExpenceHeadCrud());
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.ExpenceType.GetAll().ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = DB.ExpenceType.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }

                ExpenceHeadGrid.ItemsSource = myList;
            }

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(ExpenceHeadGrid.ItemsSource);

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {

                        if (t.Name == "GridName")
                        {
                            myList= DB.ExpenceType.GetAll().Where(x=>x.ExpenceName.ToUpper().StartsWith(filter.ToUpper())).ToList();                            
                        }

                    ExpenceHeadGrid.ItemsSource = myList;


                }
            }
        }
        private void ResetPaging(List<DAL.DBMODEL.ExpenceType> ListTopagenate)
        {
            ExpenceHeadGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            ExpenceHeadGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            ExpenceHeadGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void First_Click(object sender, RoutedEventArgs e)
        {
            ExpenceHeadGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            ExpenceHeadGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBMODEL.ExpenceType ExpenceType = (DAL.DBMODEL.ExpenceType)ExpenceHeadGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlExpenceHeadCrud(ExpenceType));
        }
    }
}
