using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.UserControls.Define.List;
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
    /// <summary>
    /// Interaction logic for UserControlProductCrud.xaml
    /// </summary>
    public partial class UserControlProductCrud : UserControl
    {
        public UserControlProductCrud(ProductDTO Product=null)
        {
            InitializeComponent();
            RefreshPage();            
            if (Product != null)
            {
                InitializePage(Product);
            }
        }
       

        private void InitializePage(ProductDTO Product)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;

            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Productdata = Db.Product.GetAll().Where(x => x.Id == Product.Id).FirstOrDefault();

                if (!string.IsNullOrEmpty(Productdata?.Barcode))
                {
                    txtPCode.Text = Productdata?.Barcode;
                    txtPCode.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(Productdata?.ProductName))
                {
                    txtProductName.Text = Productdata?.ProductName;
                    txtProductName.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(Productdata?.ProductName))
                {
                    txtProductUrduName.Text = Productdata.ProductName;
                    txtProductUrduName.Foreground = Brushes.Black;
                }
                if (Productdata?.Size != null)
                {
                    txtSize.Text = Convert.ToString(Productdata.Size);
                    txtSize.Foreground = Brushes.Black;
                }
                if (Productdata.RetailPrice != null )

                {
                    txtSalePrice.Text = Productdata.RetailPrice.ToString();
                    txtSalePrice.Foreground = Brushes.Black;
                }

                if (Productdata.Wholesaleprice != null)
                {
                    txtWholeSalePrice.Text = Productdata.Wholesaleprice.ToString();
                    txtWholeSalePrice.Foreground = Brushes.Black;
                }
                if (Productdata.PurchasePrice != null)
                {
                    txtPurchasePrice.Text = Productdata.PurchasePrice.ToString();
                    txtPurchasePrice.Foreground = Brushes.Black;
                }

                if (Productdata.CategoryId != null && Productdata.CategoryId>0)
                {
                    DDCategory.SelectedValue = Productdata.CategoryId;                   
                }
                if (Productdata.SubcategoryId != null && Productdata.SubcategoryId > 0)
                {
                    DDSubCategory.SelectedValue = Productdata.SubcategoryId;
                }
                if (Productdata.GroupId != null && Productdata.GroupId > 0)
                {
                    DDGroup.SelectedValue = Productdata.GroupId;
                }
                if (Productdata.ShelfId != null && Productdata.ShelfId > 0)
                {
                    DDShelf.SelectedValue = Productdata.ShelfId;
                }
                if (Productdata.Unit != null && Productdata.Unit > 0)
                {
                    DDMunit.SelectedValue = Productdata.Unit;
                }
                //CurrentStock
                //Supplier
                //Maximum
                //Minimum
                //StockDate

                txtId.Text = Productdata.Id.ToString();
            }

        }
        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DDCategory.ItemsSource = Db.ProductCategory.GetAll().ToList();
                DDSubCategory.ItemsSource = null;
                DDGroup.ItemsSource = Db.ProductGroup.GetAll().ToList();
                DDShelf.ItemsSource = Db.Shelf.GetAll().ToList();
                DDSupplier.ItemsSource = Db.Supplier.GetAll().ToList();
                DDMunit.ItemsSource = Db.MUnit.GetAll().ToList();

            }
            txtPCode.Text = "";
            txtProductName.Text = "";
            txtProductUrduName.Text = "";
            txtSalePrice.Text = "";
            txtWholeSalePrice.Text = "";
            txtPurchasePrice.Text = "";
            txtStock.Text = "";
            txtStockMin.Text = "";
            txtStockMax.Text = "";
            txtSize.Text = "";
            DateStock.SelectedDate = DateTime.Today;

            txtId.Text = "";
        }
        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Text)
            {
                case "Product Code":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Product Name":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Product Urdu Name":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Sale Price":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "WholeSale Price":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Purchase Price":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Current Stock":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Minimum Stock":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Maximum Stock":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Size":
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
                case "txtPCode":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Product Code";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtProductName":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Product Name";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtProductUrduName":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Product Urdu Name";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtSalePrice":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Sale Price";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtWholeSalePrice":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "WholeSale Price";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtPurchasePrice":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Purchase Price";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtStock":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Current Stock";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtStockMin":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Minimum Stock";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtStockMax":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Maximum Stock";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtSize":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Size";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //restCust customer = new restCust();
            //customer.fkrest = ActiveSession.restaurant.pkcode;
            //customer.fname = txtFName.Text;
            //customer.lname = txtLName.Text;
            //customer.email = txtEmail.Text;

            //if(txtDob.Text != "dd/mm/yyyy")
            //{
            //    try { customer.dob = DateTime.ParseExact(txtDob.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
            //    catch { MessageBoxUI.ShowCustom("Date is not in specific format", "Date of Birth Input Error", "Ok"); }
            //}

            //customer.phone1 = txtCont1.Text;
            //customer.phone2 = txtCont2.Text;
            //customer.HomeNo = txtHome.Text;
            //customer.Address = txtAddress.Text;
            //customer.PostalCode = txtPostal.Text;
            //customer.note = txtNote.Text;

            //if (string.IsNullOrWhiteSpace(customer.fname) || string.IsNullOrWhiteSpace(customer.phone1))
            //{
            //    MessageBoxUI.ShowCustom("Please provide data for mandatory (*) fields", "Input Error", "OK");
            //    return;
            //}
            //else
            //{
            //    if(isUpdate)
            //    {
            //        uow.restCusts.Update(customer, customer.pkcode);
            //        int i = uow.Complete();
            //        if (i == 1)
            //            MessageBoxUI.ShowCustom("Data successfully updated.", "Data Updated", "OK");
            //    }
            //    else
            //    {
            //        uow.restCusts.Add(customer);
            //        int i = uow.Complete();
            //        if (i == 1)
            //            MessageBoxUI.ShowCustom("Data saved successfully.", "Data Saved", "OK");
            //    }

            //}
        }        
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // customer NewCustomer = new customer();
            // NewCustomer.bill_name = txtFName.Text;
            // NewCustomer.surname = txtLName.Text;
            //// NewCustomer.address = txtPostal.Text;
            // NewCustomer.updateon = Date.Text;

            // customer.AddCustomer(NewCustomer);

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (txtId.Text != "" && txtId.Text != "0")
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        Product NewProduct = DB.Product.Get(Id);
                        NewProduct.Barcode = txtPCode.Text;
                        NewProduct.ProductName = txtProductName.Text;
                        //urduName
                        NewProduct.RetailPrice = Convert.ToDecimal(txtSalePrice.Text);
                        NewProduct.Wholesaleprice = Convert.ToDecimal(txtWholeSalePrice.Text);
                        NewProduct.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
                        NewProduct.CategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                        NewProduct.SubcategoryId = Convert.ToInt32(DDSubCategory.SelectedValue);
                        if (DDGroup.SelectedValue != null) 
                        {
                            NewProduct.GroupId = Convert.ToInt32(DDGroup.SelectedValue);
                        }
                        if (DDGroup.SelectedValue != null) 
                        {
                            NewProduct.ShelfId = Convert.ToInt32(DDShelf.SelectedValue);
                        }
                        //CurrentStock
                        //Supplier
                        //Maximum
                        //Minimum
                        //StockDate
                        NewProduct.Createdon = DateTime.Now;
                        NewProduct.Unit = Convert.ToInt32(DDMunit.SelectedValue);
                        NewProduct.Size = Convert.ToDecimal(txtSize.Text.Trim());

                        DB.Complete();
                        EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                        RefreshPage();

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
                    Product NewProduct = new Product();
                    NewProduct.Barcode = txtPCode.Text;
                    NewProduct.ProductName = txtProductName.Text;
                    //urduName
                    NewProduct.RetailPrice = Convert.ToDecimal(txtSalePrice.Text);
                    NewProduct.Wholesaleprice = Convert.ToDecimal(txtWholeSalePrice.Text);
                    NewProduct.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
                    NewProduct.CategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                    NewProduct.SubcategoryId = Convert.ToInt32(DDSubCategory.SelectedValue);
                    if(DDGroup.SelectedValue != null) 
                    {
                        NewProduct.GroupId = Convert.ToInt32(DDGroup.SelectedValue);
                    }
                    if (DDGroup.SelectedValue != null) 
                    {
                        NewProduct.ShelfId = Convert.ToInt32(DDShelf.SelectedValue);
                    }
                    //CurrentStock
                    //Supplier
                    //Maximum
                    //Minimum
                    //StockDate
                    NewProduct.Unit = Convert.ToInt32(DDMunit.SelectedValue);
                    NewProduct.Size = Convert.ToDecimal(txtSize.Text);
                    NewProduct.Createdon = DateTime.Today;
                    DB.Product.Add(NewProduct);
                    DB.Complete();
                    EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                    RefreshPage();

                }

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete Record?", "Yes", "No");
            if (Isconfirm)
            {

                if (txtId.Text != "" && txtId.Text != "0")
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        try
                        {
                            DB.Product.Delete(Id);
                            EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                            RefreshPage();
                        }
                        catch
                        {
                            EZYPOS.View.MessageBox.ShowCustom("Selected Product Can't be Deleted because its being used", "Status", "OK");
                        }
                    }
                }
            }

        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtPCode.Text) || txtPCode.Text == "Product Code")
            {
                EZYPOS.View.MessageBox.ShowCustom("Product Code is Required.", "Error", "OK");
                return false;

            }
            if (string.IsNullOrEmpty(txtProductName.Text) || txtProductName.Text == "Product Name")
            {
                EZYPOS.View.MessageBox.ShowCustom("Product Name is Required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtSalePrice.Text) || txtSalePrice.Text == "Sale Price")
            {
                EZYPOS.View.MessageBox.ShowCustom("Sale Price is Required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtPurchasePrice.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Purchase Price is Required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtWholeSalePrice.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Whole Sale Price is Required.", "Error", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtSize.Text) || string.IsNullOrWhiteSpace(txtSize.Text))
            {
                EZYPOS.View.MessageBox.ShowCustom("Size is Required.", "Error", "OK");
                return false;
            }
            //if (string.IsNullOrEmpty(txtStock.Text) || txtStock.Text == "Current Stock")
            //{
            //    EZYPOS.View.MessageBox.ShowCustom("Current Stock is Required.", "Error", "OK");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtStockMax.Text) || txtStockMax.Text == "Maximum Stock")
            //{
            //    EZYPOS.View.MessageBox.ShowCustom("Maximum Stock is Required.", "Error", "OK");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtStock.Text) || txtStock.Text == "Current Stock")
            //{
            //    EZYPOS.View.MessageBox.ShowCustom("Current Stock is Required.", "Error", "OK");
            //    return false;
            //}
            if (DDCategory.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select Category.", "Error", "OK");
                return false;
            }
            if (DDSubCategory.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select SubCategory.", "Error", "OK");
                return false;
            }
            if (DDMunit.SelectedValue == null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please select Measuring Unit.", "Error", "OK");
                return false;
            }
            //if (DDGroup.SelectedValue == null)
            //{
            //    EZYPOS.View.MessageBox.ShowCustom("Please select Group.", "Error", "OK");
            //    return false;
            //}

            return true;
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListProduct());
        }

        private void DDCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                if (DDCategory.SelectedItem != null)
                {
                    DDSubCategory.ItemsSource = Db.ProductSubcategory.GetAll().Where(x=> x.CategoryId == Convert.ToInt32(DDCategory.SelectedValue)).ToList();
                }
            }
        }
    }
}
