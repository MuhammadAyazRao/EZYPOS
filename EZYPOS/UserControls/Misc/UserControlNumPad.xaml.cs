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

namespace EZYPOS.UserControls.Misc
{
    public delegate void ButtonPressedHandler(object sender, EventArgs e);
    /// <summary>
    /// Interaction logic for UserControlNumPad.xaml
    /// </summary>
    public partial class UserControlNumPad : UserControl
    {
        public event ButtonPressedHandler OnButtonPressed;
        public string pin { get; set; }
        public UserControlNumPad()
        {
            InitializeComponent();
            lblPin.Content = 0;
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
                        lblPin.Content = string.IsNullOrEmpty(lblPin.Content.ToString()) || string.IsNullOrWhiteSpace(lblPin.Content.ToString()) ? 0 : Convert.ToInt32(lblPin.Content.ToString());
                        pin = btn.Content.ToString();
                    }
                    else
                    {
                        lblPin.Content += (string)btn.Content;
                        lblPin.Content = string.IsNullOrEmpty(lblPin.Content.ToString()) || string.IsNullOrWhiteSpace(lblPin.Content.ToString()) ? 0 : Convert.ToInt32(lblPin.Content.ToString());
                        pin += (string)btn.Content;
                    }

                    OnButtonPressed?.Invoke(this, null);

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
               
                if ((lblPin.Content.ToString() != string.Empty) && (pin != string.Empty))
                {
                    lblPin.Content = lblPin.Content.ToString().Remove(lblPin.Content.ToString().Length - 1);
                    lblPin.Content = string.IsNullOrEmpty(lblPin.Content.ToString()) || string.IsNullOrWhiteSpace(lblPin.Content.ToString()) ? 0 : Convert.ToInt32(lblPin.Content.ToString());
                    pin = pin.Remove(pin.Length - 1);                    
                }
                OnButtonPressed?.Invoke(this, null);
            }
            catch (Exception exp)
            { EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok"); }
        }

        private void ClearPin()
        {
            pin = 0.ToString();
            lblPin.Content = pin;
            lblPin.Content = string.IsNullOrEmpty(lblPin.Content.ToString()) || string.IsNullOrWhiteSpace(lblPin.Content.ToString()) ? 0 : Convert.ToInt32(lblPin.Content.ToString());

            OnButtonPressed?.Invoke(this, null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearPin();
        }
    }
}
