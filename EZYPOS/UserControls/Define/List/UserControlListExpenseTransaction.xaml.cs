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
            Refresh();
        }
        private void Refresh(object sender = null)
        {

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.expt.GetAll().Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName,}).ToList();
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
            //ExpenceTransaction exp = (ExpenceTransaction)DG_Etransaction.SelectedItem;
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
                        myList = DB.expt.GetAll().Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                        ResetPaging(myList);
                    }
                    else
                    {
                        {
                            {

                                if (t.Name == "GridEtype")
                                {
                                    myList = DB.expt.GetAll().Where(x => x.ExpenceTypeNavigation.ExpenceName.ToUpper().Contains(filter.ToUpper())).ToList().Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                                    ResetPaging(myList);
                                }
                                if (t.Name == "GridDiscription")
                                {
                                    myList = DB.expt.GetAll().Where(x => x.Discription.ToUpper().Contains(filter.ToUpper())).ToList().Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                                    ResetPaging(myList);
                                }
                                if (t.Name == "GridAmount")
                                {
                                    myList = DB.expt.GetAll().Where(x => x.Amount.ToString().Contains(filter)).ToList().Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                                    ResetPaging(myList);
                                }
                                if (t.Name == "GridTtype")
                                {
                                    myList = DB.expt.GetAll().Where(x => x.ExpenceDate.ToString().ToUpper().Contains(filter.ToUpper())).ToList().Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                                    ResetPaging(myList);
                                }
                            }
                        };
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.expt.GetAll().Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = DB.expt.GetAll().Where(x => x.ExpenceDate >= Sdate && x.ExpenceDate <= Edate).Select(x => new ExpenseTransactionDTO { Id = x.Id, ExpenseDate = Convert.ToDateTime(x.ExpenceDate), CreateBy = Convert.ToInt32(x.CreatedBy), Discription = x.Discription, Amount = Convert.ToInt32(x.Amount), Isdeleted = Convert.ToBoolean(x.Isdeleted), ExpenseType = x.ExpenceTypeNavigation == null ? null : x.ExpenceTypeNavigation.ExpenceName, }).ToList();
                }

                ResetPaging(myList);

            }
        }
    }
}
