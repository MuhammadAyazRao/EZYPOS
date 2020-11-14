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
    /// Interaction logic for MessageUI.xaml
    /// </summary>
    public partial class MessageUI : Window
    {
        public MessageUI()
        {
            InitializeComponent();
        }

        public MessageUI(string message, string title, string buttonTitle) : this()
        {
            lblTitle.Content = title;
            lblMessage.Text = message;
            //lblMessage.Content = message;
            btnOk.Content = buttonTitle;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
