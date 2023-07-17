using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for NumPad.xaml
    /// </summary>
    public partial class NumPad : Window
    {
        // Import the necessary WinAPI method to send a key press event
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // Define the virtual key code for the Enter key
        private const byte VK_ENTER = 0x0D;
        private TextBox targetTextBox; // The textbox in the other window

        public NumPad(TextBox textBox, Window window)
        {
            InitializeComponent();
            var screens = System.Windows.Forms.Screen.AllScreens;
            var firstSecondary = screens.FirstOrDefault(s => s.Primary == false);
            if (firstSecondary != null)
            {
                WindowStartupLocation = WindowStartupLocation.Manual;
                // Ensure Window is minimzed on creation
                //WindowState = WindowState.Minimized; //XAML
                // Define Position on Secondary screen, for "Normal" window-mode
                // ( Here Top/Left-Position )
                Left = firstSecondary.Bounds.Left;
                Top = firstSecondary.Bounds.Top;
            }
            targetTextBox = textBox; // Store the reference to the textbox

            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Activate();
            targetTextBox.Focus();
            var textBoxPoint = targetTextBox.PointToScreen(new Point(50, 50));
            Left = textBoxPoint.X;
            Top = textBoxPoint.Y - Height;
            Topmost = true;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            targetTextBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Content.ToString();

            if (targetTextBox != null)
            {
                targetTextBox.Text += digit;
                targetTextBox.Focus();
            }
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (targetTextBox != null && targetTextBox.Text.Length > 0)
            {
                targetTextBox.Text = targetTextBox.Text.Substring(0, targetTextBox.Text.Length - 1);
                targetTextBox.Focus();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (targetTextBox != null)
            {
                targetTextBox.Text = string.Empty;
                targetTextBox.Focus();
            }
        }
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            //if (targetTextBox != null)
            //{
            //    targetTextBox.KeyDown += Barcode_KeyDown();
            //    //targetTextBox.Focus();
            //}
            

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }
}