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
    /// Interaction logic for EditQuantity.xaml
    /// </summary>
    public partial class EditQuantity : Window
    {
        string FocusedTextBox = "";
        public string Qty = "0";
        public EditQuantity()
        {
            InitializeComponent();
            txtQty.Focus();
            Refresh();
        }
        public void Refresh()
        {
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
                    
                    if (FocusedTextBox == "txtQty")
                    {
                        if (txtQty.Text == "0")
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

        private void DotClick(object sender, RoutedEventArgs e)
        {
            
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
