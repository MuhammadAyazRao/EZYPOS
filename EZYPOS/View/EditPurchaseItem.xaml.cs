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
    /// Interaction logic for EditPurchaseItem.xaml
    /// </summary>
    public partial class EditPurchaseItem : Window
    {
        string FocusedTextBox = "";
        public DateTime Start_Date = DateTime.Today;
        public DateTime End_Date = DateTime.Today;
        public string Discount = "0";
        public string Qty = "0";
        public EditPurchaseItem()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            StartDate.SelectedDate = Start_Date;
            EndDate.SelectedDate = End_Date;
            txtDiscount.Text = Discount;
            txtQty.Text = Qty;
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
                    if (FocusedTextBox == "txtDiscount")
                    {
                        if (txtDiscount.Text == "0")
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
                        if (txtQty.Text == "0")
                        {
                            txtQty.Text = (string)btn.Content;
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
        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtDiscount":
                    FocusedTextBox = "txtDiscount";
                    break;
                case "txtQty":
                    FocusedTextBox = "txtQty";
                    break;
            }
        }
    }
}
