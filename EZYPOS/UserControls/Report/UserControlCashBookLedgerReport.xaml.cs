using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
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

namespace EZYPOS.UserControls.Report
{
    /// <summary>
    /// Interaction logic for UserControlCashBookLedgerReport.xaml
    /// </summary>
    public partial class UserControlCashBookLedgerReport : UserControl
    {
        List<CashBookLedgerDTO> myList = new List<CashBookLedgerDTO>();
        Pager<CashBookLedgerDTO> Pager = new Helper.Pager<CashBookLedgerDTO>();
        public UserControlCashBookLedgerReport()
        {
            InitializeComponent();
            Refresh();
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;

        }


        void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                var items = Db.CashBookLead.GetAll().Where(x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate).ToList();
                decimal? TotalDR = 0;
                decimal? TotalCR = 0;
                decimal? TotalBalance = 0;
                myList.Clear();
                foreach (var item in items)
                {
                    item.DrAmt = item.DrAmt == null ? 0 : item.DrAmt;
                    item.CrAmt = item.CrAmt == null ? 0 : item.CrAmt;

                    TotalDR += item.DrAmt;
                    TotalCR += item.CrAmt;
                    TotalBalance = TotalDR - TotalCR;
                    myList.Add(new CashBookLedgerDTO {Date = item.TransactionDate, TransactionType = item.TransactionType, Detail = item.TransactionDetail, CR = item.CrAmt, DR = item.DrAmt, Balance = TotalBalance });
                }
                ResetPaging(myList);

            }
        }
        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;

                using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        Refresh();
                    }
                    else
                    {

                        if (t.Name == "GridName")
                        {

                        }
                    }
                    ResetPaging(myList);
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<CashBookLedgerDTO> ListTopagenate)
        {
            CashBookLedgerGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CashBookLedgerGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CashBookLedgerGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            CashBookLedgerGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CashBookLedgerGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }


        #endregion

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}