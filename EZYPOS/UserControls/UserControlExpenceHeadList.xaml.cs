using EZYPOS.DBModels;
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
        public UserControlExpenceHeadList(bool Ismenu=false)
        {
            if (Ismenu)
            {
                ActiveSession.RefreshExpenceHead += Refresh;
            }
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (EPOSDBContext DB = new EPOSDBContext())
            {
                var Expencelist = DB.ExpenceTypes.ToList();
                ExpenceHeadGrid.ItemsSource = Expencelist;
            }
        }

        private void AddExpenceHead_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlExpenceHeadCrud());
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHome("");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<ExpenceType> ExpenceTypes;
            using (EPOSDBContext DB = new EPOSDBContext())
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    ExpenceTypes = DB.ExpenceTypes.ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    ExpenceTypes = DB.ExpenceTypes.Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }

                ExpenceHeadGrid.ItemsSource = ExpenceTypes;
            }

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                var cv = CollectionViewSource.GetDefaultView(ExpenceHeadGrid.ItemsSource);
                if (filter == "")
                    cv.Filter = null;
                else
                {
                    cv.Filter = o =>
                    {
                        ExpenceType List = o as ExpenceType;

                        if (t.Name == "GridName")
                        {
                            return List.ExpenceName.ToUpper().StartsWith(filter.ToUpper());                            
                        }                        
                        else
                        {
                            return true;
                        }                   


                    };
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ExpenceType ExpenceType = (ExpenceType)ExpenceHeadGrid.SelectedItem;
            ActiveSession.NavigateToSwitchScreen(new UserControlExpenceHeadCrud(ExpenceType));
        }
    }
}
