using Common;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.DTO.ReportsDTO;
using EZYPOS.Helper;
using EZYPOS.UserControls.Define.Crud;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CashSummaryReport.xaml
    /// </summary>
    public partial class CashSummaryReport : UserControl
    {
        List<CashSummary> myList { get; set; }
        Pager<CashSummary> Pager = new Helper.Pager<CashSummary>();

        public CashSummaryReport()
        {
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today;
            EndDate.SelectedDate = DateTime.Today;

            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate != null || EndDate != null)
                {
                    DateTime Sdate = Convert.ToDateTime(StartDate.SelectedDate);
                    DateTime Edate = Convert.ToDateTime(EndDate.SelectedDate).Date.AddDays(1).AddMilliseconds(-1);
                    myList = DB.CashSummary.GetAll().Where(x => x.StartDate >= Sdate && x.StartDate <= Edate).OrderByDescending(x => x.Id).ToList();
                    ResetPaging(myList);
                }
                else
                {
                    myList = DB.CashSummary.GetAll().Where(x => x.IsActive == false).OrderByDescending(x => x.Id).ToList();
                    ResetPaging(myList);
                }
            }   
        }

        private void ResetPaging(List<CashSummary> ListTopagenate)
        {
            DG_CashSummary.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ExpenseTransactionDTO exp = (ExpenseTransactionDTO)DG_CashSummary.SelectedItem;
            ActiveSession.DisplayuserControlMethod(new UserControlExpenseTransactionCrud(exp));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.DisplayuserControlMethod(new UserControlExpenseTransactionCrud());
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
                        Refresh();
                    }
                    else
                    {
                        if (t.Name == "GridEtype")
                        {
                            

                        }
                        if (t.Name == "GridDiscription")
                        {
                        }
                        if (t.Name == "GridAmount")
                        {
                        }
                        if (t.Name == "GridTDate")
                        {
                        }
                    }
                    ResetPaging(myList);
                }
            }

        }

        private void btnBackwards_Click(object sender, RoutedEventArgs e)
        {
            DG_CashSummary.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            DG_CashSummary.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            DG_CashSummary.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            DG_CashSummary.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.StartAmount.ToString(), COLB = x.StartDate.ToString(), COLC = x.StartedBy, COLD = x.EndAmount.ToString(), COLE = x.EndDate.ToString(), COLF = x.EndedBy }).ToList();
            string Discription = "From: " + StartDate.SelectedDate?.ToString("dd/MM/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("dd/MM/yyyy");
            ReportPrintHelper.PrintCOL6Report(ref ReportViewer, "Cash Summary Report", "Start Amount", "Start Date", "Started By", "End Amount","End Date","Ended By", Discription, RptData);

        }
    }
}
