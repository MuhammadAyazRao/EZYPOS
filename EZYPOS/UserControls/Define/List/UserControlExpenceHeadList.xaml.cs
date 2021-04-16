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
    /// Interaction logic for UserControlExpenceHeadList.xaml
    /// </summary>
    public partial class UserControlExpenceHeadList : UserControl
    {
        List<DAL.DBModel.ExpenceType> myList { get; set; }
        Pager<DAL.DBModel.ExpenceType> Pager = new Helper.Pager<DAL.DBModel.ExpenceType>();
        public UserControlExpenceHeadList()
        {
            
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                myList = DB.ExpenceType.GetAll().ToList();
                ExpenceHeadGrid.ItemsSource = myList;
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

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
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

                using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                {

                        if (t.Name == "GridName")
                        {
                            myList= DB.ExpenceType.GetAll().Where(x=>x.ExpenceName.ToUpper().StartsWith(filter.ToUpper())).ToList();                            
                        }

                    ExpenceHeadGrid.ItemsSource = myList;


                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBModel.ExpenceType ExpenceType = (DAL.DBModel.ExpenceType)ExpenceHeadGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlExpenceHeadCrud(ExpenceType));
        }
    }
}
