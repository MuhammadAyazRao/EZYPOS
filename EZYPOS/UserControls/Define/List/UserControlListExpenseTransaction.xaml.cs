using Common.Session;
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
using DAL.DBModel;
using DAL.Repository;
using EZYPOS.UserControls.Define.Crud;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System.Text.RegularExpressions;

namespace EZYPOS.UserControls.Define.List
{
    /// <summary>
    /// Interaction logic for UserControlListExpenseTransaction.xaml
    /// </summary>
    public partial class UserControlListExpenseTransaction : UserControl
    {
        List<ExpenseTransactionDTO> myList { get; set; }
        Pager<ExpenseTransactionDTO> Pager = new Helper.Pager<ExpenseTransactionDTO>();
        public UserControlListExpenseTransaction()
        {
            InitializeComponent();
            StartDate.SelectedDate = DateTime.Today;
            EndDate .SelectedDate = DateTime.Today;
            Refresh();
        }
        private void Refresh(object sender = null)
        {

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                myList = DB.expt.GetAll().Where(x => x.ExpenceDate >= Sdate && x.ExpenceDate <= Edate).Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, EmployeeName = x.Employee == null ? null : x.Employee.UserName }).ToList();
                ResetPaging(myList);

            }
        }

        private void ResetPaging(List<ExpenseTransactionDTO> ListTopagenate)
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
            ActiveSession.CloseDisplayuserControlMethod(new UserControlExpenseTransactionCrud());

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
                        DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Today : StartDate.SelectedDate.Value;
                        DateTime Edate = EndDate.SelectedDate == null ? DateTime.Today : EndDate.SelectedDate.Value;
                        myList = DB.expt.GetAll().Where(x => x.ExpenceDate >= Sdate && x.ExpenceDate <= Edate).Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, EmployeeName = x.Employee == null ? null : x.Employee.UserName }).ToList();
                        if (t.Name == "GridEtype")
                        {
                            myList = myList.Where(x => x.ExpenseType.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridEmployee")
                        {
                            myList = myList.Where(x => x.EmployeeName.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridDiscription")
                        {
                            myList = myList.Where(x => x.Discription.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridAmount")
                        {
                            myList = myList.Where(x => x.Amount.ToString().Contains(filter)).ToList();
                        }
                        if (t.Name == "GridTDate")
                        {
                            myList = myList.Where(x => x.ExpenseDate.ToString().Contains(filter)).ToList();
                        }
                        ResetPaging(myList);
                    }
                    
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

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            ExpenseTransactionDTO exp = (ExpenseTransactionDTO)DG_Etransaction.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This Record?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    try
                    {
                        DB.expt.Delete(exp.Id);
                        DB.expt.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                        Refresh();
                    }
                    catch
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Selected Record Can't be Deleted", "Status", "OK");
                    }

                }
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
