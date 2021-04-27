﻿using DAL.DBModel;
using DAL.Repository;
using EZYPOS.DTO;
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

            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                var Productdata = Db.Product.GetAll().Where(x => x.Id == Product.Id).FirstOrDefault();

                if (!string.IsNullOrEmpty(Productdata?.ProductName))
                {
                    txtPCode.Text = Productdata?.Barcode;
                    txtPCode.Foreground = Brushes.Black;
                }
                if (!string.IsNullOrEmpty(Productdata?.ProductName))
                {
                    txtProductName.Text = Productdata?.ProductName;
                    txtProductName.Foreground = Brushes.Black;
                }
                //if (!string.IsNullOrEmpty(Productdata?.ProductName))
                //{
                //    txtProductUrduName.Text = Productdata.ProductName;
                //    txtProductUrduName.Foreground = Brushes.Black;
                //}
                if (Productdata.RetailPrice!=null)

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
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                DDCategory.ItemsSource = Db.ProductCategory.GetAll().ToList();
                DDSubCategory.ItemsSource = Db.ProductSubcategory.GetAll().ToList();
                DDGroup.ItemsSource = Db.ProductGroup.GetAll().ToList();
                DDSupplier.ItemsSource = Db.Supplier.GetAll().ToList();
            }
            txtPCode.Text = "Product Code";
            txtPCode.Foreground = Brushes.Gray;

            txtProductName.Text = "Product Name";
            txtProductName.Foreground = Brushes.Gray;

            txtProductUrduName.Text = "Product Urdu Name";
            txtProductUrduName.Foreground = Brushes.Gray;

            txtSalePrice.Text = "Sale Price";
            txtSalePrice.Foreground = Brushes.Gray;

            txtWholeSalePrice.Text = "WholeSale Price";
            txtWholeSalePrice.Foreground = Brushes.Gray;

            txtPurchasePrice.Text = "Purchase Price";
            txtPurchasePrice.Foreground = Brushes.Gray;

            txtStock.Text = "Current Stock";
            txtStock.Foreground = Brushes.Gray;

            txtStockMin.Text = "Minimum Stock";
            txtStockMin.Foreground = Brushes.Gray;

            txtStockMax.Text = "Maximum Stock";
            txtStockMax.Foreground = Brushes.Gray;

            DateStock.SelectedDate = DateTime.Now;

            txtId.Text = "";
        }
        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Update Record?", "Yes", "No");
            if (Isconfirm)
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
                            NewProduct.RetailPrice = Convert.ToInt32(txtSalePrice.Text);
                            NewProduct.Wholesaleprice = Convert.ToInt32(txtWholeSalePrice.Text);
                            NewProduct.PurchasePrice = Convert.ToInt32(txtPurchasePrice.Text);
                            NewProduct.CategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                            NewProduct.SubcategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                            NewProduct.GroupId = Convert.ToInt32(DDGroup.SelectedValue);
                            //CurrentStock
                            //Supplier
                            //Maximum
                            //Minimum
                            //StockDate
                            NewProduct.Createdon = DateTime.Now;                          
                            DB.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                            RefreshPage();

                        }
                    }

                }
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Save Record?", "Yes", "No");
            if (Isconfirm)
            {
                if (Validate())
                {
                    using (UnitOfWork DB = new UnitOfWork(new EPOSDBContext()))
                    {
                        Product NewProduct = new Product();
                        NewProduct.Barcode = txtPCode.Text;
                        NewProduct.ProductName = txtProductName.Text;
                        //urduName
                        NewProduct.RetailPrice = Convert.ToInt32(txtSalePrice.Text);
                        NewProduct.Wholesaleprice = Convert.ToInt32(txtWholeSalePrice.Text);
                        NewProduct.PurchasePrice = Convert.ToInt32(txtPurchasePrice.Text);
                        NewProduct.CategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                        NewProduct.SubcategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                        NewProduct.GroupId = Convert.ToInt32(DDGroup.SelectedValue);
                        //CurrentStock
                        //Supplier
                        //Maximum
                        //Minimum
                        //StockDate
                        NewProduct.Createdon = DateTime.Now;
                        DB.Product.Add(NewProduct);
                        DB.Complete();
                        EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                         RefreshPage();

                    }

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
                        DB.Product.Delete(Id);                        
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                        RefreshPage();
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
            if (string.IsNullOrEmpty(txtPurchasePrice.Text) || txtPurchasePrice.Text == "Purchase Price")
            {
                EZYPOS.View.MessageBox.ShowCustom("Purchase Price is Required.", "Error", "OK");
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
            //if (DDGroup.SelectedValue == null)
            //{
            //    EZYPOS.View.MessageBox.ShowCustom("Please select Group.", "Error", "OK");
            //    return false;
            //}

            return true;
        }
    }
}