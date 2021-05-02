using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChromeTabs;
using Common.Session;
using EZYPOS.Helper.Session;
using EZYPOS.UserControls;
using EZYPOS.UserControls.Define.Crud;
using EZYPOS.UserControls.Define.List;
using EZYPOS.UserControls.Misc;
using EZYPOS.UserControls.Report;
using EZYPOS.UserControls.Transaction;
using EZYPOS.View;
using MessageBox = EZYPOS.View.MessageBox;

namespace EZYPOS
{
    /// <summary>
    /// Interaction logic for MainWindowNewMenu.xaml
    /// </summary>
    public partial class MainWindowNewMenu : Window
    {
        public MainWindowNewMenu()
        {
            InitializeComponent();
            ActiveSession.DisplayuserControl += DisplayUserControl;
            ActiveSession.CloseDisplayuserControl += CloseDisplayUserControl;
            MenuItem mnuDeleteInvoice = new MenuItem();

            mnuDeleteInvoice.Header = "Test Dynamic";        
            mnuDeleteInvoice.Template =(ControlTemplate) FindResource("VsMenuSub");
            mnuDeleteInvoice.Tag = "EZYPOS.UserControls.UserControlListCustomer";
            mnuDeleteInvoice.Click += MenuItem_Click;
            mnuDeleteInvoice.Height = 50;
            //mnuDeleteInvoice.Icon = new System.Windows.Controls.Image
            //{
            //    Source = new BitmapImage(new Uri("Assets//icons//icon_queries.png", UriKind.Relative))
            //};
            //mnuDeleteInvoice.Icon = new MaterialDesignThemes.Wpf.PackIcon { Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete };
            VSOnline.Items.Add(mnuDeleteInvoice);

           
        }

        #region Misc
        private void EditStatusCm_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                ContextMenu cm = mi.CommandParameter as ContextMenu;
                if (cm != null)
                {
                    Grid g = cm.PlacementTarget as Grid;
                    if (g != null)
                    {
                        Console.WriteLine(g.Background); // Will print red
                    }
                }
            }
        }
        private void LoadUserControl(string controlName)
        {
            Type ucType = null;
            UserControl uc = null;

            // Create a Type from controlName parameter
            ucType = Type.GetType(controlName);
            if (ucType == null)
            {
                MessageBox.ShowCustom("The Control: " + controlName + " does not exist.","Invalid","OK");
            }
            else
            {
                // Close current user control in content area
                //CloseUserControl();

                // Create an instance of this control
                uc = (UserControl)Activator.CreateInstance(ucType);
                if (uc != null)
                {
                    // Display control in content area
                    DisplayUserControl(uc);
                }
            }
        }
        public void CloseDisplayUserControl(object Usercontrol)
        {
            this.chrometabs.RemoveTab(this.chrometabs.SelectedItem);
            DisplayUserControl(Usercontrol);
        }
        public void DisplayUserControl(object Usercontrol)  
        {
            // Add new user control to content area
            // contentArea.Children.Add(uc);
            UserControl uc = (UserControl)Usercontrol;
            this.chrometabs.AddTab(this.GenerateNewItem(uc), true);
        }       
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = (MenuItem)sender;
            string cmd = string.Empty;

            // The Tag property contains a command or the name of a user control to load
            if (mnu.Tag != null)
            {
                cmd = mnu.Tag.ToString();
                if (cmd.Contains("."))
                {
                    // Display a user control
                    LoadUserControl(cmd);
                }
                else
                {
                    // Process special commands
                   // ProcessMenuCommands(cmd);
                }
            }
        }
        private int newTabNumber;

        private void HandleAddTab(object sender, RoutedEventArgs e)
        {
            this.chrometabs.AddTab(this.GenerateNewItem(), false);
        }
        private object GenerateNewItem(UserControl UC=null)
        {
            object itemToAdd = null;
            string ItemName = "Nil";

            //object itemToAdd = new UserControl1();
            if (UC == null)
            { itemToAdd = new Button { Content = "Moo " + this.newTabNumber }; }
            else
            {
                itemToAdd = UC;
                ItemName = ((UserControl)itemToAdd).Name;
                
            }
            Interlocked.Increment(ref this.newTabNumber);
            //if (this.title.Text.Length > 0)
            {
                itemToAdd = new ChromeTabs.ChromeTabItem
                {
                    Header = ItemName,
                    Content = itemToAdd
                };
            }
            return itemToAdd;
        }
        #endregion
        #region Menu Click Event
        private void Cutomers_Click(object sender, RoutedEventArgs e)
        {
            UserControlListCustomer Customer = new UserControlListCustomer();
            ActiveSession.DisplayuserControlMethod(Customer);
               // DisplayUserControl(Customer);
        }

        private void Cities_Click(object sender, RoutedEventArgs e)
        {
            UserControlListCity City = new UserControlListCity();
            ActiveSession.DisplayuserControlMethod(City);
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            UserControlListEmployee Employee = new UserControlListEmployee();
            ActiveSession.DisplayuserControlMethod(Employee);
        }

        private void Expence_Click(object sender, RoutedEventArgs e)
        {
            UserControlExpenceHeadList ExpenceHead = new UserControlExpenceHeadList();
            ActiveSession.DisplayuserControlMethod(ExpenceHead);
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            UserControlListCategory Category = new UserControlListCategory();
            ActiveSession.DisplayuserControlMethod(Category);
            
        }

        private void SubCategory_Click(object sender, RoutedEventArgs e)
        {
            UserControlListSubCategory Subcategory = new UserControlListSubCategory();
            ActiveSession.DisplayuserControlMethod(Subcategory);
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            UserControlListGroup Group = new UserControlListGroup();
            ActiveSession.DisplayuserControlMethod(Group);
        }

        #endregion

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            UserControlListProduct Product = new UserControlListProduct();
            ActiveSession.DisplayuserControlMethod(Product);
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            UserControlListSupplier Supplier = new UserControlListSupplier();
            ActiveSession.DisplayuserControlMethod(Supplier);
        }

        private void SaleItem_Click(object sender, RoutedEventArgs e)
        {
            UserControlSaleTransaction SaleItem = new UserControlSaleTransaction();
            ActiveSession.DisplayuserControlMethod(SaleItem);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen Login = new LoginScreen();
            Login.Show();
            this.Close();
            
        }

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            UserControlPurchaseTransaction PurchaseItem = new UserControlPurchaseTransaction();
            ActiveSession.DisplayuserControlMethod(PurchaseItem);
        }

        private void ReturnItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomerReceipt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SupplierPayment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Barcode_Click(object sender, RoutedEventArgs e)
        {
            UserControlBarCode Barcode = new UserControlBarCode();
            ActiveSession.DisplayuserControlMethod(Barcode);
        }

        private void ViewOrder_Click(object sender, RoutedEventArgs e)
        {
            UserControlViewOrder OrderScreen = new UserControlViewOrder();
            ActiveSession.DisplayuserControlMethod(OrderScreen);

        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            UserControlStockExpiry UserControlStockExpiry = new UserControlStockExpiry();
            ActiveSession.DisplayuserControlMethod(UserControlStockExpiry);
        }
    }
}
