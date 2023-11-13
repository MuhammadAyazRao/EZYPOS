using Common;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.UserControls.Define.Crud;
using Stripe;
using System;
using System.Collections.Generic;
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

namespace EZYPOS.UserControls.Define.List
{
    /// <summary>
    /// Interaction logic for UserControlListPriceRules.xaml
    /// </summary>
    public partial class UserControlListPriceRules : UserControl
    {
        List<PriceRuleDTO> myList { get; set; }
        Pager<PriceRuleDTO> Pager = new Helper.Pager<PriceRuleDTO>();
        public UserControlListPriceRules()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.PriceRule.GetAll().Where(x=> x.IsDeleted == false ||  x.IsDeleted == null).Select(x => new PriceRuleDTO { Id = x.Id, Name = x.Name, RuleType = GetTypeDisplayText(x.Type), StartDate = x.StartDate, EndDate = x.EndDate, IsActive = x.IsActive }).ToList();
                ResetPaging(myList);
            }
        }
        private static string GetTypeDisplayText(string value)
        {
            return Regex.Replace(value.ToString(), "([A-Z])", " $1").TrimStart();
        }
        private void btnAddPriceRule_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlPriceRules());
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {

            EZYPOS.DTO.PriceRuleDTO priceRuleObj = (EZYPOS.DTO.PriceRuleDTO)priceRuleGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlPriceRules(priceRuleObj));
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.PriceRuleDTO priceRuleObj = (EZYPOS.DTO.PriceRuleDTO)priceRuleGrid.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This Price Rule?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    try
                    {
                        var deletePriceRule = DB.PriceRule.Get(priceRuleObj.Id);
                        deletePriceRule.IsDeleted = true;
                        DB.Complete();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                        Refresh();
                    }
                    catch
                    {
                        EZYPOS.View.MessageBox.ShowCustom("An Error occured while deleting this record", "Status", "OK");
                    }

                }
            }
        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    myList = DB.PriceRule.GetAll().Where(x=> x.IsDeleted == false || x.IsDeleted == null).Select(x => new PriceRuleDTO { Id = x.Id, Name = x.Name, RuleType = GetTypeDisplayText(x.Type), StartDate = x.StartDate, EndDate = x.EndDate, IsActive = x.IsActive }).ToList();
                    if (filter == "")
                    {
                    }
                    else
                    {
                        if (t.Name == "GridName")
                        {
                            myList = myList.Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridRuleType")
                        {
                            myList = myList.Where(x => x.RuleType.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridStartDate")
                        {
                            myList = myList.Where(x => x.StartDate.ToString().Contains(filter)).ToList();
                        }
                        if (t.Name == "GridEndDate")
                        {
                            myList = myList.Where(x => x.EndDate.ToString().Contains(filter)).ToList();
                        }
                    }
                    ResetPaging(myList);
                }
            }

        }


        #region Pagination

        private void ResetPaging(List<PriceRuleDTO> ListTopagenate)
        {
            priceRuleGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            priceRuleGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            priceRuleGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void First_Click(object sender, RoutedEventArgs e)
        {
            priceRuleGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            priceRuleGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        #endregion
    }
}
