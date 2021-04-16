using EZYPOS.DTO;
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
    /// Interaction logic for UserControlInvoice.xaml
    /// </summary>
    public partial class UserControlInvoice : UserControl
    {
        public UserControlInvoice()
        {
            InitializeComponent();
        }        

        private List<FlowDocument> flowDocuments = null;
        private int totalDoc;
        private int crntDoc = 0;

       

        public void SetFlowDoc(List<FlowDocument> flowDocuments)
        {
            this.flowDocuments = flowDocuments;
            totalDoc = flowDocuments.Count - 1;
            this.FlowDocScrol.Document = flowDocuments[0];
        }


        
    }
}
