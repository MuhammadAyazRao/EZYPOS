using Common.DTO;
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
using System.Windows.Shapes;

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for ManualItem.xaml
    /// </summary>
    public partial class ManualItem : Window
    {
        public ManualItem()
        {
            InitializeComponent();
        }
        public OrderDetail ManualMenuitem;
        
        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Text)
            {
                case "Name":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Price":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Qty":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Discount":
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
                case "txtName":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Name";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtQty":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Qty";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtPrice":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Price";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
                case "txtDiscount":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Discount";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Validateform() == true)
            {
                ManualMenuitem = new OrderDetail() { Item = new item { name = txtName.Text, price = Convert.ToInt32(txtPrice.Text) }, Qty = Convert.ToInt32(txtQty.Text) , ItemDiscount = Convert.ToInt32(txtDiscount.Text) };
                this.DialogResult = true;
                this.Close();
            }
            else
            { EZYPOS.View.MessageBox.ShowCustom("Please fill all fields", "validation Error", "Ok"); }

        }
        private bool Validateform()
        {
            if (txtName.Text == "Name" || txtPrice.Text == "Price" || txtQty.Text == "Qty" || txtDiscount.Text == "Discount")
            {
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void TxtNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
