using EZYPOS.DBModels;
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
using System.Windows.Shapes;

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for Discount.xaml
    /// </summary>
    public partial class Discount : Window
    {
        public Discount()
        {
            InitializeComponent();
        }
        public string pin { get; set; }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (EPOSDBContext db = new EPOSDBContext())
            {


                //var user = db.shop_manager.FirstOrDefault(x => x.pin == lblPin.Password.ToString());
                //if (user != null)
                //{

                this.DialogResult = true;
                Close();
                //}
                //else
                //{
                //    lblErrMsg.Visibility = Visibility.Visible;
                //}
            }

        }

        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { btnAdd_Click(null, null); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    if (lblPin.Content.ToString() == "0")
                    {
                        lblPin.Content = (string)btn.Content;
                        pin = btn.Content.ToString();
                    }
                    else
                    {
                        lblPin.Content += (string)btn.Content;
                        pin += (string)btn.Content;
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
                if (((string)lblPin.Content != string.Empty) && (pin != string.Empty))
                {
                    lblPin.Content = lblPin.Content.ToString().Remove(lblPin.Content.ToString().Length - 1);
                    pin = pin.Remove(pin.Length - 1);

                }
            }
            catch (Exception exp)
            { EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok"); }
        }

        private void ClearPin()
        {
            lblPin.Content = "";
            pin = 1.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearPin();
        }

        private void DiscountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btndiscountpay_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btndiscountcancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }
    }
}
