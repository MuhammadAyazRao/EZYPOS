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
    /// Interaction logic for UserControlAccountType.xaml
    /// </summary>
    public delegate void BtnPressHandler(object sender, EventArgs e);
    public partial class UserControlAccountType : UserControl
    {
        public event BtnPressHandler onButtonPress;
        public UserControlAccountType()
        {
            InitializeComponent();
        }
        public void PaymentViaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             onButtonPress?.Invoke(sender, e);

        }

    }
}
