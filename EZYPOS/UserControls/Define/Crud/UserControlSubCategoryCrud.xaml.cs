using Common.Session;
using DAL.Repository;
using EZYPOS.UserControls.Define.List;
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

namespace EZYPOS.UserControls.Define.Crud
{
    /// <summary>
    /// Interaction logic for UserControlSubCategoryCrud.xaml
    /// </summary>
    public partial class UserControlSubCategoryCrud : UserControl
    {
        public UserControlSubCategoryCrud(EZYPOS.DTO.SubCategoryDTO SubCategory = null)
        {
            InitializeComponent();
            RefreshPage();

            if (SubCategory != null)
            { InitializePage(SubCategory); }
        }

        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;

            txtFName.Text = "";
            txtId.Text = "";
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                DDCategory.ItemsSource = Db.ProductCategory.GetAll().ToList();
            }

        }
        private void InitializePage(EZYPOS.DTO.SubCategoryDTO SubCategory)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var ProductSubCategory = Db.ProductSubcategory.GetAll().Where(x => x.Id == SubCategory.Id).FirstOrDefault();
                if (!string.IsNullOrEmpty(ProductSubCategory?.SubcategoryName))
                {
                    txtFName.Text = ProductSubCategory?.SubcategoryName;
                    txtFName.Foreground = Brushes.Black;
                }
                if (ProductSubCategory?.CategoryId != 0)
                {
                    DDCategory.SelectedValue = ProductSubCategory.CategoryId;
                }
                txtId.Text = ProductSubCategory.Id.ToString();
            }

        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Text)
            {
                case "Name":
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
                case "txtFName":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Name";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;


            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (txtId.Text != "" && txtId.Text != "0")
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                    {
                        var SubCategory = Db.ProductSubcategory.GetAll().Where(x => x.Id == Id).FirstOrDefault();
                        if (SubCategory != null)
                        {
                            if (!string.IsNullOrEmpty(txtFName.Text))
                            {
                                SubCategory.SubcategoryName = txtFName.Text;
                                SubCategory.CategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                            }
                            Db.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
                            RefreshPage();
                        }
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    DAL.DBMODEL.ProductSubcategory ProductSubcategory = new DAL.DBMODEL.ProductSubcategory();
                    ProductSubcategory.SubcategoryName = txtFName.Text;
                    ProductSubcategory.CategoryId = Convert.ToInt32(DDCategory.SelectedValue);
                    Db.ProductSubcategory.Add(ProductSubcategory);
                    Db.Complete();
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
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                    {
                        try
                        {
                            Db.ProductSubcategory.Delete(Convert.ToInt32(txtId.Text));
                            Db.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Deleted Successfully", "Status", "OK");
                            RefreshPage();
                        }
                        catch
                        {
                            EZYPOS.View.MessageBox.ShowCustom("Sub Category Can't be Deleted because its being used", "Status", "OK");
                        }
                    }
                }
            }
        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtFName.Text) || txtFName.Text == "Name")
            {
                EZYPOS.View.MessageBox.ShowCustom("Name is Required.", "Error", "OK");
                return false;
            }
            if (DDCategory.SelectedValue==null)
            {
                EZYPOS.View.MessageBox.ShowCustom("Category is Required.", "Error", "OK");
                return false;
            }
            return true;
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlListSubCategory());
        }
    }
}
