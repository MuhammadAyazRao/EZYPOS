using Common;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.UserControls.Define.List;
using Microsoft.CodeAnalysis.FlowAnalysis;
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

namespace EZYPOS.UserControls.Define.Crud
{
    public class PriceRuleTypeValues
    {
        public int Value { get; set; }
        public string DisplayText { get; set; }
        public static List<PriceRuleTypeValues> Values
        {
            get
            {
                return Enum.GetValues(typeof(PriceRuleTypes))
                           .Cast<PriceRuleTypes>()
                           .Select(v => new PriceRuleTypeValues
                           {
                               Value = Convert.ToInt32(v),
                               DisplayText = GetEnumDisplayText(v)
                           })
                           .ToList();
            }
        }

        private static string GetEnumDisplayText(PriceRuleTypes value)
        {
            return Regex.Replace(value.ToString(), "([A-Z])", " $1").TrimStart();
        }
    }
    /// <summary>
    /// Interaction logic for UserControlPriceRules.xaml
    /// </summary>
    public partial class UserControlPriceRules : UserControl
    {
        public string PriceRuleType { get; set; }
        public UserControlPriceRules(DTO.PriceRuleDTO priceRule = null)
        {
            InitializeComponent();
            RefreshPage();
            if (priceRule != null)
            {
                InitializePage(priceRule);
            }
        }

        private void InitializePage(PriceRuleDTO priceRule)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var priceRuleData = Db.PriceRule.GetAll().Where(x => x.Id == priceRule.Id).FirstOrDefault();

                if (!string.IsNullOrEmpty(priceRuleData?.Name))
                {
                    txtName.Text = priceRuleData?.Name;
                }
                if (!string.IsNullOrEmpty(priceRuleData?.FixedOff.ToString()))
                {
                    txtFixedOff.Text = priceRuleData?.FixedOff.ToString();
                }
                if (!string.IsNullOrEmpty(priceRuleData?.PercentOff.ToString()))
                {
                    txtPercentOff.Text = priceRuleData.PercentOff.ToString();
                }
                if (!string.IsNullOrEmpty(priceRuleData?.Description))
                {
                    txtDescription.Text = priceRuleData.Description;
                }
                if (!string.IsNullOrEmpty(priceRuleData?.StartDate.ToString()))
                {
                    startDate.SelectedDate = priceRuleData.StartDate;
                }
                if (!string.IsNullOrEmpty(priceRuleData?.EndDate.ToString()))
                {
                    endDate.SelectedDate = priceRuleData.EndDate;
                }
                if (priceRuleData?.Type != "")
                {
                    string enumText = priceRuleData?.Type;
                    bool isValidEnum = Enum.TryParse(typeof(PriceRuleTypes), enumText, out object enumValue);

                    if (isValidEnum)
                    {
                        int selectedValue = (int)enumValue;
                        ddPriceRuleType.SelectedValue = selectedValue;
                    }
                }
                txtId.Text = priceRuleData.Id.ToString();
            }

        }

        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                //var priceRuleTypes = Db.PriceRuleType.GetAll().ToList();
                var priceRuleTypes = PriceRuleTypeValues.Values;
                ddPriceRuleType.ItemsSource = priceRuleTypes;
                ddPriceRuleType.SelectedIndex = 0;
            }
            txtName.Text = "";
            txtFixedOff.Text = "";
            txtPercentOff.Text = "";
            txtDescription.Text = "";
            txtQtyToBuy.Text = "";
            txtQtyToGet.Text = "";
            txtSpendAmount.Text = "";
            startDate.Text = "";
            endDate.Text = "";
            txtId.Text = "";
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirmed = EZYPOS.View.MessageYesNo.ShowCustom("Refresh", "Do you want to refresh page?", "Yes", "No");
            if (Isconfirmed)
            { RefreshPage(); }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (txtId.Text != "" && txtId.Text != "0")
                {
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                    {
                        var updatePriceRule = Db.PriceRule.Get(Convert.ToInt32(txtId.Text));
                        if (updatePriceRule != null)
                        {
                            int selectedValue = Convert.ToInt32(ddPriceRuleType.SelectedValue);
                            updatePriceRule.Type = Enum.GetName(typeof(PriceRuleTypes), selectedValue);
                            updatePriceRule.Name = txtName.Text;
                            updatePriceRule.AddedOn = DateTime.Now;
                            updatePriceRule.StartDate = startDate.SelectedDate;
                            updatePriceRule.EndDate = endDate.SelectedDate;
                            updatePriceRule.IsActive = ckIsActive.IsChecked.Value;
                            if (PriceRuleType == PriceRuleTypes.SimpleDiscount.ToString()
                        || PriceRuleType == PriceRuleTypes.BuyXGetDiscount.ToString()
                        || PriceRuleType == PriceRuleTypes.SpendXGetDiscount.ToString())
                            {
                                if (!string.IsNullOrEmpty(txtFixedOff.Text))
                                {
                                    updatePriceRule.FixedOff = Convert.ToDecimal(txtFixedOff.Text);
                                }
                                if (!string.IsNullOrEmpty(txtFixedOff.Text))
                                {
                                    updatePriceRule.PercentOff = Convert.ToDecimal(txtPercentOff.Text);
                                }
                            }
                            if (!string.IsNullOrEmpty(txtQtyToBuy.Text))
                            {
                                updatePriceRule.ItemsToBuy = Convert.ToInt32(txtQtyToBuy.Text);
                            }
                            if (!string.IsNullOrEmpty(txtQtyToGet.Text))
                            {
                                updatePriceRule.ItemToGet = Convert.ToInt32(txtQtyToGet.Text);
                            }
                            if (!string.IsNullOrEmpty(txtSpendAmount.Text))
                            {
                                updatePriceRule.SpendAmount = Convert.ToDecimal(txtSpendAmount.Text);
                            }
                            if (!string.IsNullOrEmpty(txtDescription.Text))
                            {
                                updatePriceRule.Description = txtDescription.Text;
                            }
                            Db.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
                            RefreshPage();
                            ActiveSession.NavigateToRefreshMenu("");
                        }
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                {
                    PriceRule newPriceRule = new PriceRule();
                    int selectedValue = Convert.ToInt32(ddPriceRuleType.SelectedValue);
                    newPriceRule.Type = Enum.GetName(typeof(PriceRuleTypes), selectedValue);
                    newPriceRule.Name = txtName.Text;
                    newPriceRule.AddedOn = DateTime.Now;
                    newPriceRule.StartDate = startDate.SelectedDate;
                    newPriceRule.EndDate = endDate.SelectedDate;
                    newPriceRule.IsActive = ckIsActive.IsChecked.Value;
                    if (PriceRuleType == PriceRuleTypes.SimpleDiscount.ToString()
                || PriceRuleType == PriceRuleTypes.BuyXGetDiscount.ToString()
                || PriceRuleType == PriceRuleTypes.SpendXGetDiscount.ToString())
                    {
                        if (!string.IsNullOrEmpty(txtFixedOff.Text))
                        {
                            newPriceRule.FixedOff = Convert.ToDecimal(txtFixedOff.Text);
                        }
                        if (!string.IsNullOrEmpty(txtPercentOff.Text))
                        {
                            newPriceRule.PercentOff = Convert.ToDecimal(txtPercentOff.Text);
                        }
                    }
                    if (!string.IsNullOrEmpty(txtQtyToBuy.Text))
                    {
                        newPriceRule.ItemsToBuy = Convert.ToInt32(txtQtyToBuy.Text);
                    }
                    if (!string.IsNullOrEmpty(txtQtyToGet.Text))
                    {
                        newPriceRule.ItemToGet = Convert.ToInt32(txtQtyToGet.Text);
                    }
                    if (!string.IsNullOrEmpty(txtSpendAmount.Text))
                    {
                        newPriceRule.SpendAmount = Convert.ToDecimal(txtSpendAmount.Text);
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        newPriceRule.Description = txtDescription.Text;
                    }


                    DB.PriceRule.Add(newPriceRule);
                    DB.PriceRule.Save();
                    EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                    RefreshPage();
                    ActiveSession.NavigateToRefreshMenu("");
                }
            }
        }

        private bool Validate()
        {
            if (PriceRuleType == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select a rule type.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Rule name is required.", "Error", "OK");
                return false;

            }
            if (string.IsNullOrEmpty(startDate.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Rule start date is required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(endDate.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Rule end date is required.", "Error", "OK");
                return false;
            }
            if (PriceRuleType == PriceRuleTypes.SimpleDiscount.ToString()
                || PriceRuleType == PriceRuleTypes.BuyXGetDiscount.ToString()
                || PriceRuleType == PriceRuleTypes.SpendXGetDiscount.ToString())
            {
                if (string.IsNullOrEmpty(txtPercentOff.Text) && string.IsNullOrEmpty(txtFixedOff.Text))
                {
                    EZYPOS.View.MessageBox.ShowCustom("Please enter value in fixed off or percent off", "Error", "OK");
                    return false;
                }
                if (!string.IsNullOrEmpty(txtPercentOff.Text) && !string.IsNullOrEmpty(txtFixedOff.Text))
                {
                    EZYPOS.View.MessageBox.ShowCustom("One value must be zero between fixed off and percent off", "Error", "OK");
                    return false;
                }
            }
            if (PriceRuleType == PriceRuleTypes.BuyXGetYFree.ToString())
            {
                if (string.IsNullOrEmpty(txtQtyToBuy.Text) || string.IsNullOrEmpty(txtQtyToGet.Text))
                {
                    EZYPOS.View.MessageBox.ShowCustom("Qty to buy and Qty to get both are required.", "Error", "OK");
                    return false;
                }
            }
            if (PriceRuleType == PriceRuleTypes.BuyXGetDiscount.ToString())
            {
                if (string.IsNullOrEmpty(txtQtyToBuy.Text))
                {
                    EZYPOS.View.MessageBox.ShowCustom("Qty to buy is required.", "Error", "OK");
                    return false;
                }
            }
            if (PriceRuleType == PriceRuleTypes.SpendXGetDiscount.ToString())
            {
                if (string.IsNullOrEmpty(txtSpendAmount.Text))
                {
                    EZYPOS.View.MessageBox.ShowCustom("Spend amount is required.", "Error", "OK");
                    return false;
                }
            }
            return true;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete Record?", "Yes", "No");
            if (Isconfirm)
            {

                if (txtId.Text != "" && txtId.Text != "0")
                {
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        try
                        {
                            var deletePriceRule = DB.PriceRule.Get(Convert.ToInt32(txtId.Text));
                            deletePriceRule.IsDeleted = true;
                            DB.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                            RefreshPage();
                        }
                        catch
                        {
                            EZYPOS.View.MessageBox.ShowCustom("Error occured while deleting this record.", "Status", "OK");
                        }

                    }
                }
            }

        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListPriceRules());
        }

        private void ddPriceRuleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedValue = Convert.ToInt32(ddPriceRuleType.SelectedValue);
            PriceRuleType = Enum.GetName(typeof(PriceRuleTypes), selectedValue);
            if (PriceRuleType != null)
            {
                if (PriceRuleType == PriceRuleTypes.SimpleDiscount.ToString())
                {
                    txtFixedOff.Visibility = Visibility.Visible;
                    txtPercentOff.Visibility = Visibility.Visible;
                    txtQtyToBuy.Visibility = Visibility.Collapsed;
                    txtQtyToGet.Visibility = Visibility.Collapsed;
                    txtSpendAmount.Visibility = Visibility.Collapsed;
                }
                else if (PriceRuleType == PriceRuleTypes.BuyXGetYFree.ToString())
                {
                    txtFixedOff.Visibility = Visibility.Collapsed;
                    txtPercentOff.Visibility = Visibility.Collapsed;
                    txtQtyToBuy.Visibility = Visibility.Visible;
                    txtQtyToGet.Visibility = Visibility.Visible;
                    txtSpendAmount.Visibility = Visibility.Collapsed;
                }
                else if (PriceRuleType == PriceRuleTypes.BuyXGetDiscount.ToString())
                {
                    txtFixedOff.Visibility = Visibility.Visible;
                    txtPercentOff.Visibility = Visibility.Visible;
                    txtQtyToBuy.Visibility = Visibility.Visible;
                    txtQtyToGet.Visibility = Visibility.Collapsed;
                    txtSpendAmount.Visibility = Visibility.Collapsed;
                }
                else if (PriceRuleType == PriceRuleTypes.SpendXGetDiscount.ToString())
                {
                    txtFixedOff.Visibility = Visibility.Visible;
                    txtPercentOff.Visibility = Visibility.Visible;
                    txtQtyToBuy.Visibility = Visibility.Collapsed;
                    txtQtyToGet.Visibility = Visibility.Collapsed;
                    txtSpendAmount.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
