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
   
    /// <summary>
    /// Interaction logic for UserControlSideNumPad.xaml
    /// </summary>
    public partial class UserControlSideNumPad : UserControl
    {
        public event BtnPressHandler onButtonPress;
        public string Pin { get; set; }
        public UserControlSideNumPad()
        {
            InitializeComponent();
            btn5.Content = 5;
            btn10.Content = 10;
            btn20.Content = 20;
            btn50.Content = 50;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string btnCon = btn.Content.ToString();
            Pin = btnCon;
            onButtonPress?.Invoke(Pin, EventArgs.Empty);
        }
    }
}
