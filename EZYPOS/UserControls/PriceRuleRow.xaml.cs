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

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for PriceRuleRow.xaml
    /// </summary>
    public partial class PriceRuleRow : UserControl
    {
        public static readonly RoutedEvent RemoveRowClickedEvent =
                    EventManager.RegisterRoutedEvent("RemoveRowClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PriceRuleRow));

        public event RoutedEventHandler RemoveRowClicked
        {
            add { AddHandler(RemoveRowClickedEvent, value); }
            remove { RemoveHandler(RemoveRowClickedEvent, value); }
        }
        public string QtyToBuy => GetTextBoxValue("txtQtyToBuy");
        public string FixedOff => GetTextBoxValue("txtFixedOff");
        public string PercentOff => GetTextBoxValue("txtPercentOff");

        public string QtyToBuy1
        {
            get => txtQtyToBuy.Text;
            set => txtQtyToBuy.Text = value;
        }

        public string FixedOff1
        {
            get => txtFixedOff.Text;
            set => txtFixedOff.Text = value;
        }

        public string PercentOff1
        {
            get => txtPercentOff.Text;
            set => txtPercentOff.Text = value;
        }
        public PriceRuleRow()
        {
            InitializeComponent();
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(RemoveRowClickedEvent, this);
            RaiseEvent(args);
        }
        private string GetTextBoxValue(string textBoxName)
        {
            TextBox textBox = FindName(textBoxName) as TextBox;
            return textBox?.Text ?? string.Empty;
        }
        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtFixedOff":
                    if (tb.Text != string.Empty)
                    {
                        txtPercentOff.Text = string.Empty;
                    }
                    break;
                case "txtPercentOff":
                    if (tb.Text != string.Empty)
                    {
                        txtFixedOff.Text = string.Empty;
                    }
                    break;
            }
        }
    }
}
