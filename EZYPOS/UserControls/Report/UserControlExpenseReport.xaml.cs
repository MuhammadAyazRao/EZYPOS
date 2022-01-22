﻿using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.DTO.ReportsDTO;
using EZYPOS.Helper;
using EZYPOS.UserControls.Define.Crud;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Interaction logic for UserControlExpenseReport.xaml
    /// </summary>
    public partial class UserControlExpenseReport : UserControl
    {
        List<ExpenseReportDTO> myList = new List<ExpenseReportDTO>();
        Pager<ExpenseReportDTO> Pager = new Helper.Pager<ExpenseReportDTO>();
        public UserControlExpenseReport()
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
                var items = DB.expt.GetAll().ToList();
                if (StartDate.SelectedDate != null && EndDate.SelectedDate != null)
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                    items = items.Where(x => x.ExpenceDate >= Sdate && x.ExpenceDate <= Edate).ToList();
                }
                decimal? TotalAmount = 0;
                string expensename = "";
                myList.Clear();
                foreach(var item in items)
                {
                    
                    expensename = DB.ExpenceType.Get(Convert.ToInt32(item.ExpenceType)).ExpenceName;
                    TotalAmount += item.Amount;
                    myList.Add( new ExpenseReportDTO { ExpenseDate = item.ExpenceDate?.ToString("dd/MM/yyyy"), CreateBy = Convert.ToString(item.CreatedBy), Discription = item.Discription, Amount = item.Amount?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),  ExpenseType = expensename, });

                }
                myList.Add( new ExpenseReportDTO { ExpenseDate = "Total", CreateBy = "", Discription = "", Amount = TotalAmount?.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")), ExpenseType = "" });
                
                ResetPaging(myList);

            }
        }

        private void ResetPaging(List<ExpenseReportDTO> ListTopagenate)
        {
            DG_Etransaction.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ExpenseTransactionDTO exp = (ExpenseTransactionDTO)DG_Etransaction.SelectedItem;
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
                            var items = DB.expt.GetAll().ToList();
                            if (StartDate.SelectedDate != null && EndDate.SelectedDate != null)
                            {
                                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                                items = items.Where(x => x.ExpenceDate >= Sdate && x.ExpenceDate <= Edate).ToList();
                            }
                            decimal? TotalAmount = 0;
                            string expensename = "";
                            myList.Clear();
                            foreach (var item in items)
                            {
                                expensename = DB.ExpenceType.Get(Convert.ToInt32(item.ExpenceType)).ExpenceName;
                                if (expensename.ToUpper().Contains(filter.ToUpper()))
                                {
                                    TotalAmount += item.Amount;
                                    myList.Add(new ExpenseReportDTO { ExpenseDate = Convert.ToString(item.ExpenceDate), CreateBy = Convert.ToString(item.CreatedBy), Discription = item.Discription, Amount = Convert.ToString(item.Amount), ExpenseType = expensename, });
                                }
                            }
                            myList.Add(new ExpenseReportDTO { ExpenseDate = "Total", CreateBy = "", Discription = "", Amount = Convert.ToString(TotalAmount), ExpenseType = "" });

                            ResetPaging(myList);

                        }
                        if (t.Name == "GridDiscription")
                        {
                            //myList = DB.expt.GetAll().Where(x => x.Discription.ToUpper().Contains(filter.ToUpper())).Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                        }
                        if (t.Name == "GridAmount")
                        {
                            //myList = DB.expt.GetAll().Where(x => x.Amount.ToString().Contains(filter)).Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                        }
                        if (t.Name == "GridTDate")
                        {
                            //myList = DB.expt.GetAll().Where(x => x.ExpenceDate.ToString().ToUpper().Contains(filter.ToUpper())).Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                        }
                    }
                    ResetPaging(myList);
                }
            }

        }

        private void btnBackwards_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            DG_Etransaction.ItemsSource = Pager.Last(myList);
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
            List<GenericCOL6DTO> RptData = myList.Select(x => new GenericCOL6DTO { COLA = x.ExpenseType, COLB = x.Discription, COLC = x.ExpenseDate, COLD = x.Amount, COLE="",COLF="" }).ToList();
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "GenericCOL4DataSet";
            rds.Value = RptData;
            string exePath = Directory.GetCurrentDirectory();
            ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL4Report.rdlc";
            this.ReportViewer.LocalReport.DataSources.Add(rds);
            this.ReportViewer.LocalReport.EnableExternalImages = true;
            string imagePath = new Uri(exePath + @"\Assets\logo.png").AbsoluteUri;
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ImagePath", imagePath));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", "Expence Report"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", "Expense Type"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", "Description"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", "Date"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderD", "Amount"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderE", "H"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderF", "H"));
            string Dis = "From: " + StartDate.SelectedDate?.ToString("MM/dd/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("MM/dd/yyyy");
            string PrintDate = "Printed On: " + DateTime.Now.ToString("MM/dd/yyyy");
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDescription", Dis));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("PrintDate", PrintDate));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderDescription", "House No 36, Street No 3, Liaqt Colony, PAF Road, 49 Tail, Sargodha, Pakistan"));
            this.ReportViewer.LocalReport.SetParameters(new ReportParameter("FooterDescription", "House No 36, Street No 3, Liaqt Colony, PAF Road, 49 Tail, Sargodha, Pakistan"));
            this.ReportViewer.RefreshReport();
            this.ReportViewer.LocalReport.Print();

            //List<GenericCOL4DTO> RptData = myList.Select(x => new GenericCOL4DTO { COLA=x.ExpenseType,COLB=x.Discription,COLC=x.ExpenseDate, COLD= x.Amount}).ToList();
            //ReportDataSource rds = new ReportDataSource();
            //rds.Name = "GenericCOL4DataSet";
            //rds.Value = RptData;
            //string exePath = Directory.GetCurrentDirectory();
            //ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL4Report.rdlc";
            //this.ReportViewer.LocalReport.DataSources.Add(rds);
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", "Expence Report"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", "Expense Type"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", "Discription"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", "Date"));
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderD", "Amount"));
            //string Dis = "From: " + StartDate.SelectedDate?.ToString("MM/dd/yyyy") + ", To: " + EndDate.SelectedDate?.ToString("MM/dd/yyyy");
            //this.ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDiscription", Dis));
            //this.ReportViewer.RefreshReport();
            //this.ReportViewer.LocalReport.Print();
        }
    }
}
