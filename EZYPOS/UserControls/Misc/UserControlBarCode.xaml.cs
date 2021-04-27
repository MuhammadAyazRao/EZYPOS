using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using ZXing;

namespace EZYPOS.UserControls.Misc
{
    /// <summary>
    /// Interaction logic for UserControlBarCode.xaml
    /// </summary>
    public partial class UserControlBarCode : UserControl
    {
        public UserControlBarCode()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            var path = "newdoc.xps";
            FixedDocument fixedDoc = new FixedDocument();
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();
            fixedPage.Width = 11.69 * 96;
            fixedPage.Height = 8.27 * 96;
            var pageSize = new System.Windows.Size(11.0 * 96.0, 8.5 * 96.0);
            UserControlBarCode v = new UserControlBarCode();
            ViewModel vm = new ViewModel();
            vm.Text1 = "MyText1";
            vm.Text2 = "MyText2";
            v.DataContext = vm;
            v.UpdateLayout();
            v.Height = pageSize.Height;
            v.Width = pageSize.Width;
            v.UpdateLayout();
            fixedPage.Children.Add(v);
            ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
            fixedDoc.Pages.Add(pageContent);
            if (File.Exists(path))
                File.Delete(path);
            XpsDocument xpsd = new XpsDocument(path, FileAccess.ReadWrite);
            XpsDocumentWriter xw = XpsDocument.CreateXpsDocumentWriter(xpsd);
            xw.Write(fixedDoc);
            xpsd.Close();

        }
    }
    public class ViewModel
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
}
