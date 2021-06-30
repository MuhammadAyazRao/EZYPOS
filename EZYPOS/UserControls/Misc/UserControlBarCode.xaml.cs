using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using PrintDialog = System.Windows.Controls.PrintDialog;
using UserControl = System.Windows.Controls.UserControl;

namespace EZYPOS.UserControls.Misc
{
    /// <summary>
    /// Interaction logic for UserControlBarCode.xaml
    /// </summary>
    public partial class UserControlBarCode : UserControl
    {
        string fileName;
        public UserControlBarCode()
        {
            InitializeComponent();
            Print.IsEnabled = false;
        }

        private void SetImage(string ImagePath)
        {
            //if (File.Exists(ImagePath))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath);
                bitmap.EndInit();
                bcode.Source = bitmap;
                
            }
        }

        private FlowDocument printLable(string path, int qty)
        {
            FlowDocument f = new FlowDocument();
            try
            {
                double pageWidth = 288;

                f = new FlowDocument();
                f.PageWidth = pageWidth;
                f.PagePadding = new Thickness(10);
                f.FontFamily = new FontFamily("Verdana");
                f.FontSize = 12;
                f.PageHeight = 140;                
                Paragraph p = new Paragraph();               
                {
                    Image ReslogoImg = new Image();
                    ReslogoImg.Margin = new Thickness(0, 10, 0, 10);                   
                    ReslogoImg.Width = pageWidth;
                    ReslogoImg.Height = 120;
                    try
                    {
                        ReslogoImg.Source = new BitmapImage(new Uri(path));
                    }
                    catch (FileNotFoundException ex)
                    {
                       // Views.MessageBox.ShowCustom(ex.FileName + " Restaurant Logo not found.", "Invoice Error", "Ok");
                    }

                    p.Inlines.Add(ReslogoImg);
                    f.Blocks.Add(p);

                }

            }
            catch (Exception exp)
            {
                //Epos.Views.MessageBox.ShowCustom(exp.Message, "Error", "Ok");
            }
            return f;
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
           
            String BarcodeFile = "Barcode"+DateTime.Now.ToString("MMddyyyyHHmmss") + ".jpg";
           
             fileName = string.Format(AppDomain.CurrentDomain.BaseDirectory + "{0}", @"Barcode\" + BarcodeFile);

            try
            {
                //var FolderDialog = new FolderBrowserDialog();
                //DialogResult result = FolderDialog.ShowDialog();
                //if (result == DialogResult.OK)
                {
                    //string folderName = FolderDialog.SelectedPath;
                    System.Drawing.Image image;

                    BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                    b.BackColor = System.Drawing.Color.White;//图片背景颜色
                    b.ForeColor = System.Drawing.Color.Black;//条码颜色
                    b.IncludeLabel = true;
                    b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                    b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;//code的显示位置
                    b.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;//图片格式
                    System.Drawing.Font font = new System.Drawing.Font("verdana", 10f);//字体设置
                    b.LabelFont = font;
                    b.Height = 120;//图片高度设置(px单位)
                    b.Width = 290;//图片宽度设置(px单位)

                    image = b.Encode(BarcodeLib.TYPE.UPCA, "038000356216");//生成图片
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    SetImage(fileName);
                    PrintDialog print = new PrintDialog();
                    print.PrintDocument(((IDocumentPaginatorSource)printLable(fileName, 1)).DocumentPaginator, "Test");
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
                //image = null;
            }
        }
        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void View_Click(object sender, RoutedEventArgs e)
        {
            if (txtBarcode.Text.Length < 11 || txtBarcode.Text.Length > 12)
            {
                EZYPOS.View.MessageBox.ShowCustom("Barcode Must be between 11 to 12 digits.", "Invalid", "Ok");
                return;
            }
           
            try
            {
                String BarcodeFile = "Barcode" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".jpg";
                fileName = string.Format(AppDomain.CurrentDomain.BaseDirectory + "{0}", @"Barcode\" + BarcodeFile);
                {
                   
                    System.Drawing.Image image;

                    BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                    b.BackColor = System.Drawing.Color.White;
                    b.ForeColor = System.Drawing.Color.Black;
                    b.IncludeLabel = true;
                    b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                    b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                    b.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    System.Drawing.Font font = new System.Drawing.Font("verdana", 10f);
                    b.LabelFont = font;
                    b.Height = 120;
                    b.Width = 290;

                    image = b.Encode(BarcodeLib.TYPE.UPCA, txtBarcode.Text);//生成图片
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    SetImage(fileName);
                    Print.IsEnabled = true;
                   
                }
            }
            catch (Exception err)
            {
                err.ToString();
                //image = null;
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.PrintDocument(((IDocumentPaginatorSource)printLable(fileName, 1)).DocumentPaginator, "Test");
            
            bcode.Source = null;
            //if (File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}

        }
    }
    public class ViewModel
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
}
