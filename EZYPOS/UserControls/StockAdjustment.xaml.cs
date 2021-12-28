using DAL.DBMODEL;
using DAL.Repository;
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

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for StockAdjustment.xaml
    /// </summary>
    public partial class StockAdjustment : UserControl
    {
        public StockAdjustment()
        {
            InitializeComponent();
            RefreshPage();
        }
        void RefreshPage()
        {
            
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                var expt = uw.Product.GetAll().ToList();
                ddProduct.ItemsSource = expt;
            }
            txtUpdatequantity.Text = "Update Availabe Stock";
            txtUpdatequantity.Foreground = Brushes.Gray;
            lblAvailableStock.Content = "";
        }
         void GetTotalAvailableStock()
        {
            int id = Convert.ToInt32(ddProductStock.SelectedValue);
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                if (ddProductStock.SelectedItem != null)
                {
                    long TotalStock = 0;
                    ProductStock StockInformation = uw.ProductStock.GetAll().Where(x => x.Id == id).FirstOrDefault();
                    {
                        TotalStock += StockInformation.Qty + (StockInformation.Adjustment);
                        foreach (var subitem in uw.StockOderDetail.GetAll().Where(x => x.StockId == StockInformation.Id).ToList())
                        {
                            TotalStock = TotalStock - subitem.Qty;
                        }
                    }
                    lblAvailableStock.Content = Convert.ToString(TotalStock);
                }

            }
        }
        

        private void ddProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt32(ddProduct.SelectedValue);
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                var SelectedProductStock = uw.ProductStock.GetAll().Where(x=> x.ProductId==id).ToList();
                ddProductStock.ItemsSource = SelectedProductStock;

            }

        }
        private void ddProductStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetTotalAvailableStock();
        }

        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Text)
            {
                case "Update Availabe Stock":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
            }
        }
        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtUpdatequantity":
                    if (txtUpdatequantity.Text == "")
                    {
                        tb.Text = "Update Availabe Stock";
                        tb.Foreground = Brushes.Gray;

                    }
                    break;

            }
        }
        
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }


        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (ddProductStock.SelectedItem == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Product And Expiry Date Of Stock You Want to Adjust", "Message", "Ok");

            }
            else
            {
                if(txtUpdatequantity.Text== "Update Availabe Stock")
                {
                    EZYPOS.View.MessageBox.ShowCustom("Please Provide Quantity to adjust Stock", "Message", "Ok");
                }
                else
                {
                    bool isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do You Want to Increase Available Stock", "Yes", "No");
                    if (isconfirm)
                    {
                        using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
                        {
                            int StockToIncrease = Convert.ToInt32(txtUpdatequantity.Text);
                            var SelectedProductQuantity = uw.ProductStock.GetAll().Where(x => x.Id == Convert.ToInt32(ddProductStock.SelectedValue)).FirstOrDefault();
                            int Stock = Convert.ToInt32(SelectedProductQuantity.Adjustment);
                            int AdjustedStock = StockToIncrease + Stock;
                            SelectedProductQuantity.Adjustment = AdjustedStock;
                            uw.ProductStock.Save();
                            GetTotalAvailableStock();
                            txtUpdatequantity.Text = "Update Availabe Stock";
                            txtUpdatequantity.Foreground = Brushes.Gray;
                        }
                    }
                    
                }
            }
        }

        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {
            if (ddProductStock.SelectedItem == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Select Product And Expiry Date Of Stock You Want to Adjust","Message", "Ok");
            }
            else
            {
                if (txtUpdatequantity.Text == "Update Availabe Stock")
                {
                    EZYPOS.View.MessageBox.ShowCustom("Please Provide Quantity To Update", "Message", "Ok");
                }
                else
                {
                    using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
                    {
                        int StockToDecrease = Convert.ToInt32(txtUpdatequantity.Text);
                        var SelectedProductStock = uw.ProductStock.GetAll().Where(x => x.Id == Convert.ToInt32(ddProductStock.SelectedValue)).FirstOrDefault();
                        int Stock = Convert.ToInt32(SelectedProductStock.Adjustment);
                        bool isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do You Want to Decrease Available Stock", "Yes", "No");
                        if (isconfirm)
                        {
                            
                                int AdjustedStock = Stock - StockToDecrease;
                                SelectedProductStock.Adjustment = AdjustedStock;
                                uw.ProductStock.Save();
                                GetTotalAvailableStock();
                                txtUpdatequantity.Text = "Update Availabe Stock";
                                txtUpdatequantity.Foreground = Brushes.Gray;
                        }
                    }
                }
            }
        }

        
    }
}
