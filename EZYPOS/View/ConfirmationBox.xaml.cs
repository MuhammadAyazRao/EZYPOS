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
    /// Interaction logic for ConfirmationBox.xaml
    /// </summary>
    public partial class ConfirmationBox : Window
    {
        public ConfirmationBox()
        {
            InitializeComponent();
        }
        public ConfirmationBox(string title, string message, string buttonAccept, string buttonReject) : this()
        {
            lblTitle.Content = title;
            lblMessage.Content = message;
            btnAccept.Content = buttonAccept;
            btnReject.Content = buttonReject;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
