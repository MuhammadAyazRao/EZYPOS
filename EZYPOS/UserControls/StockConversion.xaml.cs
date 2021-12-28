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
    /// Interaction logic for StockConversion.xaml
    /// </summary>
    public partial class StockConversion : UserControl
    {
        public StockConversion()
        {
            InitializeComponent();
            RefreshPage();
        }
        void RefreshPage()
        {
            
            Save.IsEnabled = true;
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                var expt = uw.ProductCategory.GetAll().ToList();
                ddCategory.ItemsSource = expt;

            }
            
        }
        public long GetTotalAvailableStock()
        {
            long TotalStock = 0;

            int id = Convert.ToInt32(ddProduct.SelectedValue);
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                if (ddProduct.SelectedItem != null)
                {
                    var StockInformations = uw.ProductStock.GetAll().Where(x => x.ProductId == id).ToList();
                    foreach (var StockInfo in StockInformations)
                    {
                        if (StockInfo != null)
                        {
                            TotalStock += StockInfo.Qty + (StockInfo.Adjustment) + (long)StockInfo.Conversion ;
                            foreach (var subitem in uw.StockOderDetail.GetAll().Where(x => x.StockId == StockInfo.Id).ToList())
                            {
                                TotalStock = TotalStock - subitem.Qty;
                            }
                        }
                    }
                }

            }
            return TotalStock;

        }

        public long GetConvertToTotalAvailableStock()
        {
            long TotalStock = 0;

            int id = Convert.ToInt32(ddCTProduct.SelectedValue);
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                if (ddProduct.SelectedItem != null)
                {
                    var StockInformations = uw.ProductStock.GetAll().Where(x => x.ProductId == id).ToList();
                    foreach (var StockInfo in StockInformations)
                    {
                        if (StockInfo != null)
                        {
                            TotalStock += StockInfo.Qty + (StockInfo.Adjustment) + (long)StockInfo.Conversion ;
                            foreach (var subitem in uw.StockOderDetail.GetAll().Where(x => x.StockId == StockInfo.Id).ToList())
                            {
                                TotalStock = TotalStock - subitem.Qty;
                            }
                        }
                    }
                }

            }
            return TotalStock;

        }


        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ddCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                var data = uw.ProductSubcategory.GetAll().Where(x => x.CategoryId == Convert.ToInt32(ddCategory.SelectedValue)).ToList();
                ddSubCategory.ItemsSource = data;
            }
        }

        private void ddSubCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                var data = uw.Product.GetAll().Where(x => x.SubcategoryId == Convert.ToInt32(ddSubCategory.SelectedValue)).ToList();
                ddProduct.ItemsSource = data;
                ddCTProduct.ItemsSource = data;
            }
        }

        private void ddProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         long TotalStock = GetTotalAvailableStock();
            lblAvailableStock.Content = TotalStock;
        }
        private void ddCTProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            long CTTotalStock = GetConvertToTotalAvailableStock();
            lblCTAvailableStock.Content = CTTotalStock;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            long TotalStock = GetTotalAvailableStock();
            long CTTotalStock = GetConvertToTotalAvailableStock();
            using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                ProductStock CFPS = uw.ProductStock.GetAll().Where(x => x.ProductId == Convert.ToInt32(ddProduct.SelectedValue)).FirstOrDefault();
                ProductStock CTPS = uw.ProductStock.GetAll().Where(x => x.ProductId == Convert.ToInt32(ddCTProduct.SelectedValue)).FirstOrDefault();
                Product CFP = uw.Product.GetAll().Where(x => x.Id == Convert.ToInt32(ddProduct.SelectedValue)).FirstOrDefault();
                Product CTP = uw.Product.GetAll().Where(x => x.Id == Convert.ToInt32(ddCTProduct.SelectedValue)).FirstOrDefault();
                Unit CFU = uw.MUnit.GetAll().Where(x => x.Id == CFP.Unit).FirstOrDefault();
                Unit CTU = uw.MUnit.GetAll().Where(x => x.Id == CTP.Unit).FirstOrDefault();
                if (CFU.Name == "KG" && CTU.Name == "G")
                {
                    int CFtotalGrams = Convert.ToInt32(CFP.Size) * Convert.ToInt32(TotalStock) * 1000;
                    int CTConversion = CFtotalGrams / Convert.ToInt32(CTP.Size);
                    CFPS.Conversion = CFPS.Conversion - Convert.ToInt32(TotalStock);
                    CTPS.Conversion = CTPS.Conversion + CTConversion;
                    uw.Complete();
                }
                if (CFU.Name == "G" && CTU.Name == "KG")
                {
                    int CFtotalGrams = Convert.ToInt32(CFP.Size) * Convert.ToInt32(TotalStock);
                    int CTConversion = (CFtotalGrams/1000) / Convert.ToInt32(CTP.Size);
                    CFPS.Conversion = CFPS.Conversion - Convert.ToInt32(TotalStock);
                    CTPS.Conversion = CTPS.Conversion + CTConversion;
                    uw.Complete();
                }


            }
            lblAvailableStock.Content = GetTotalAvailableStock();
            lblCTAvailableStock.Content = GetConvertToTotalAvailableStock();
        }


    }
}
