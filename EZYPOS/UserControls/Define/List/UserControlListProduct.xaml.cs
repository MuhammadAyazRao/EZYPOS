using DAL.DBModel;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.Helper.Session;
using EZYPOS.UserControls.Define.Crud;
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

namespace EZYPOS.UserControls.Define.List
{
    /// <summary>
    /// Interaction logic for UserControlListProduct.xaml
    /// </summary>
    public partial class UserControlListProduct : UserControl
    {
        List<ProductDTO> myList { get; set; }
        Pager<ProductDTO> Pager = new Helper.Pager<ProductDTO>();
        public UserControlListProduct()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                myList = DB.Product.GetAll().Select(x => new ProductDTO { Id = x.Id, ProductName = x.ProductName, Barcode=x.Barcode, RetailPrice=x.RetailPrice,Wholesaleprice=x.Wholesaleprice,PurchasePrice=x.PurchasePrice,CategoryName=x.Category.Name,SubcategoryName=x.Subcategory.SubcategoryName}).ToList();                
                ResetPaging(myList);
            }
        }     

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlProductCrud());

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
            {
                myList = DB.Product.GetAll().Select(x => new ProductDTO { Id = x.Id, ProductName = x.ProductName, Barcode = x.Barcode, RetailPrice = x.RetailPrice, Wholesaleprice = x.Wholesaleprice, PurchasePrice = x.PurchasePrice, CategoryName = x.Category.Name, SubcategoryName = x.Subcategory.SubcategoryName }).ToList();

                if (StartDate.SelectedDate != null && EndDate.SelectedDate != null)
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = myList.Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
                }
                MainGrid.ItemsSource = myList;
            }

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                {
                    myList = DB.Product.GetAll().Select(x => new ProductDTO { Id = x.Id, ProductName = x.ProductName, Barcode = x.Barcode, RetailPrice = x.RetailPrice, Wholesaleprice = x.Wholesaleprice, PurchasePrice = x.PurchasePrice, CategoryName = x.Category.Name, SubcategoryName = x.Subcategory.SubcategoryName }).ToList();

                    if (filter == "")
                    {

                        ResetPaging(myList);
                    }
                    else
                    {
                        if (t.Name == "GridBarcode")
                        {
                            myList = myList.Where(x => x.Barcode.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridProductName")
                        {
                            myList = myList.Where(x => x.ProductName.ToUpper().Contains(filter.ToUpper())).ToList();                          
                        }

                        if (t.Name == "GridRetailPrice")
                        {
                            myList = myList.Where(x => x.RetailPrice.ToString().ToUpper().Contains(filter.ToUpper())).ToList();                           
                        }

                        if (t.Name == "GridWholesaleprice")
                        {
                            myList = myList.Where(x => x.Wholesaleprice.ToString().ToUpper().Contains(filter.ToUpper())).ToList();                           
                        }
                        if (t.Name == "GridPurchasePrice")
                        {
                            myList = myList.Where(x => x.PurchasePrice.ToString().ToUpper().Contains(filter.ToUpper())).ToList();                            
                        }
                        if (t.Name == "GridCategoryName")
                        {
                            myList = myList.Where(x => x.CategoryName.ToUpper().Contains(filter.ToUpper())).ToList();                            
                        }
                        if (t.Name == "GridSubcategoryName")
                        {
                            myList = myList.Where(x => x.SubcategoryName.ToUpper().Contains(filter.ToUpper())).ToList();                           
                        }
                        ResetPaging(myList);
                    }
                }
            }

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

            EZYPOS.DTO.ProductDTO Product= (EZYPOS.DTO.ProductDTO)MainGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlProductCrud(Product));

        }
        #region Pagination
        private void ResetPaging(List<ProductDTO> ListTopagenate)
        {
            MainGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            MainGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
       

        private void First_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        
        #endregion
    }
}
