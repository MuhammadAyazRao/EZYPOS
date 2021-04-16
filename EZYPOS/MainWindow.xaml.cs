
using EPOSNOW.UserControls;

using EZYPOS.Helper.Session;
using EZYPOS.DTO;
using EZYPOS.UserControls;
using EZYPOS.View;
using EZYPOS.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace EZYPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            ActiveSession.NavigateToHomeView += ActiveSession_NavigateToHomeView;                      
            ActiveSession.SwitchScreen += ActiveSession_SwitchScreen;
            ActiveSession.ShowMenu += ShowMenu;
            ActiveSession.HideMenu += HideMenu;
            ActiveSession.RefreshMenu += RefreshMenu;
            RefreshMenu();
            ActiveSession_NavigateToHomeView("");

        }

        private void RefreshMenu(object sender=null)
        {
            Menu.Children.Clear();
            var item7 = new ItemMenu("Settings", null, PackIconKind.Settings, new UserControlCustomers());
            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Customers", new UserControlListCustomer()));
            menuRegister.Add(new SubItem("Suppliers", new UserControlListSupplier(true)));
            menuRegister.Add(new SubItem("ExpenceHead", new UserControlExpenceHeadList()));
            menuRegister.Add(new SubItem("Employee", new UserControlListEmployee()));
            menuRegister.Add(new SubItem("Product", new UserControlProductList()));
            // menuRegister.Add(new SubItem("Providers", new UserControlProviders()));

            menuRegister.Add(new SubItem("Employees"));
            menuRegister.Add(new SubItem("Products"));
            var item6 = new ItemMenu("Define", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Transaction", new UserControlTransaction()));
            menuSchedule.Add(new SubItem("Meetings"));
            var item1 = new ItemMenu("Appointments", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Customers"));
            menuReports.Add(new SubItem("Providers"));
            menuReports.Add(new SubItem("Products"));
            menuReports.Add(new SubItem("Stock"));
            menuReports.Add(new SubItem("Sales"));
            var item2 = new ItemMenu("Reports", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Fixed"));
            menuExpenses.Add(new SubItem("Variable"));
            var item3 = new ItemMenu("Expenses", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Cash flow"));
            var item4 = new ItemMenu("Financial", menuFinancial, PackIconKind.ScaleBalance);

            Menu.Children.Add(new UserControlMenuItem(item6, this,true));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item7, this));           
        }

       

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToHomeView -= ActiveSession_NavigateToHomeView;
            ActiveSession.SwitchScreen -= ActiveSession_SwitchScreen;           
            ActiveSession.ShowMenu -= ShowMenu;
            ActiveSession.HideMenu -= HideMenu;
            ActiveSession.RefreshMenu -= RefreshMenu;
            LoginScreen Login = new LoginScreen();
            Login.Show();
            Close();
        }
        private void HideMenu(object sender)
        {
            ColMenu.Width = new GridLength(0);
            ColShowMenu.Width = new GridLength(50);
            //MasterMenu.Visibility = Visibility.Collapsed;
            //StackPanelMain.SetValue(Grid.ColumnSpanProperty, 2);
        }

        private void ShowMenu(object sender)
        {
            ColMenu.Width = new GridLength(175);
            ColShowMenu.Width = new GridLength(0);
            //MasterMenu.Visibility = Visibility.Visible;
            //StackPanelMain.SetValue(Grid.ColumnSpanProperty, 1);
        }

        #region Active Session Controls
        private void ActiveSession_NavigateToHomeView(object parameter)
        {
            StackPanelMain.Children.Clear();
            StackPanelMain.Children.Add(new UserControlHome());
        }

        private void ActiveSession_SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
        #endregion

        private void HideMenu_Click(object sender, RoutedEventArgs e)
        {
            HideMenu("");

        }

        private void ShowMenubtn_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu("");
        }
    }
}
