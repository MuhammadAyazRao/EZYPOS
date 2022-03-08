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
    /// Interaction logic for EditSaleItem.xaml
    /// </summary>
    public partial class EditSaleItem : Window
    {
        string FocusedTextBox = "";
        public string Price = "0";
        public string Discount = "0";
        public string Qty = "0";
        public EditSaleItem()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            txtSalePrice.Text = Price;
            txtDiscount.Text = Discount;
            txtQty.Text = Qty;
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberDecimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    if(FocusedTextBox == "txtSalePrice")
                    {
                        if(txtSalePrice.Text == "0")
                        {
                            txtSalePrice.Text = (string)btn.Content;
                        }
                        else
                        {
                            txtSalePrice.Text += (string)btn.Content;
                        }
                    }

                    if (FocusedTextBox == "txtDiscount")
                    {
                        if(txtDiscount.Text == "0")
                        {
                            txtDiscount.Text = (string)btn.Content;
                        }
                        else
                        {
                            txtDiscount.Text += (string)btn.Content;
                        }
                    }
                    if (FocusedTextBox == "txtQty")
                    {
                        if(txtQty.Text == "0")
                        {
                            txtQty.Text += (string)btn.Content;
                        }
                        else
                        {
                            txtQty.Text += (string)btn.Content;
                        }
                    }

                }
            }
            catch (Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok");
            }


        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FocusedTextBox == "txtSalePrice")
                {
                    if (txtSalePrice.Text != string.Empty)
                    {
                        txtSalePrice.Text = txtSalePrice.Text.Remove(txtSalePrice.Text.Length - 1);
                    }
                }  
                if (FocusedTextBox == "txtDiscount")
                {
                    if (txtDiscount.Text != string.Empty)
                    {
                        txtDiscount.Text = txtDiscount.Text.Remove(txtDiscount.Text.Length - 1);
                    }
                }  
                if (FocusedTextBox == "txtQty")
                {
                    if (txtQty.Text != string.Empty)
                    {
                        txtQty.Text = txtQty.Text.Remove(txtQty.Text.Length - 1);
                    }
                }
                    
            }
            catch (Exception exp)
            { EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok"); }
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        //----- gotfocus and lost focust start

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtSalePrice":
                    FocusedTextBox = "txtSalePrice";
                    break;
                case "txtDiscount":
                    FocusedTextBox = "txtDiscount";
                    break;
                case "txtQty":
                    FocusedTextBox = "txtQty";
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
                

            }
        }

        //----gotfocus and lostfocus end
    }
}
