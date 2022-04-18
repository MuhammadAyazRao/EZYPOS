using Common;
using Common.Session;
using DAL.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UserControlSettings.xaml
    /// </summary>
    public partial class UserControlSettings : UserControl
    {
        public List<CountryCurrencyPair> CurrencyList { get; set; }
        public UserControlSettings()
        {
            InitializeComponent();
            CurrencyList = GetCountryList();
            Refresh();
        }
        public List<CountryCurrencyPair> GetCountryList()
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Select(c => new RegionInfo(c.LCID)).Distinct()
            .Select(r => new CountryCurrencyPair()
            {
                Country = r.EnglishName,
                Currency = "en-"+r.Name
            }).ToList();
        }
        public class CountryCurrencyPair
        {
            public string Country { get; set; }
            public string Currency { get; set; }
        }
        public void Refresh()
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    ddInvoicePrinter.Items.Add(item);
                    ddReportPrinter.Items.Add(item);
                }
                ddCurrency.ItemsSource = CurrencyList;
                ddCustomer.ItemsSource = Db.Customers.GetAll().Select(x=> new {Name = x.Name, Id = x.Id }).ToList();
                ddSupplier.ItemsSource = Db.Supplier.GetAll().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                var SettingData = Db.Setting.GetAll().ToList();
                // Invoice Printer
                var inv_print = SettingData.Where(x => x.AppKey == SettingKey.PrintInvoice).FirstOrDefault().AppValue;
                if (inv_print.ToLower()=="true")
                {
                    ckPrintInvoice.IsChecked = true;
                }
                else
                {
                    ckPrintInvoice.IsChecked = false;
                }
                var Logo_prnt = SettingData.Where(x => x.AppKey == SettingKey.PrintLogo).FirstOrDefault().AppValue;
                if (Logo_prnt.ToLower() == "true")
                {
                    ckPrintLogo.IsChecked = true;
                }
                else
                {
                    ckPrintLogo.IsChecked = false;
                }
                var rpt_prnt = SettingData.Where(x => x.AppKey == SettingKey.PrintReport).FirstOrDefault().AppValue;
                if (rpt_prnt.ToLower() == "true")
                {
                    ckPrintReport.IsChecked = true;
                }
                else
                {
                    ckPrintReport.IsChecked = false;
                }
                var Print_Confirmation = SettingData.Where(x => x.AppKey == SettingKey.PrintConfirmation).FirstOrDefault().AppValue;
                if (Print_Confirmation.ToLower() == "true")
                {
                    ckPrintConfirmation.IsChecked = true;
                }
                else
                {
                    ckPrintConfirmation.IsChecked = false;
                }
                var ExpiryAlert = SettingData.Where(x => x.AppKey == SettingKey.ExpiryAlert).FirstOrDefault().AppValue;
                if (ExpiryAlert.ToLower() == "true")
                {
                    ckExpiryAlert.IsChecked = true;
                }
                else
                {
                    ckExpiryAlert.IsChecked = false;
                }

                //image
                string imgDirPath = Environment.CurrentDirectory + @"\Assets\";
                string ImgFullPath = imgDirPath + "logo.png";
                //BitmapImage myBitmap = new BitmapImage(new Uri(ImgFullPath));

                //var myImage = myBitmap.Clone();
                //UserImage.Source = myImage;
                //ImageSelector.Content = "Logo";
                SetImage(ImgFullPath);
                //image End

                txtShopName.Text = SettingData.Where(x => x.AppKey == SettingKey.ShopName).FirstOrDefault().AppValue; ;
                txtHeader.Text = SettingData.Where(x => x.AppKey == SettingKey.ReportFooter).FirstOrDefault().AppValue;
                txtFooter.Text = SettingData.Where(x => x.AppKey == SettingKey.ReportFooter).FirstOrDefault().AppValue;
                txtMaxNoPrints.Text = SettingData.Where(x => x.AppKey == SettingKey.MaxNoPrints).FirstOrDefault().AppValue;
                txtExpiryAlertMonths.Text = SettingData.Where(x => x.AppKey == SettingKey.ExpiryAlertMonths).FirstOrDefault().AppValue;
                ddInvoicePrinter.SelectedItem = SettingData.Where(x => x.AppKey == SettingKey.InvoicePrinter).FirstOrDefault().AppValue;
                ddReportPrinter.SelectedItem = SettingData.Where(x => x.AppKey == SettingKey.ReportPrinter).FirstOrDefault().AppValue;
                ddCurrency.SelectedValue = SettingData.Where(x => x.AppKey == SettingKey.Currency).FirstOrDefault().AppValue;
                ddSupplier.SelectedValue = SettingData.Where(x => x.AppKey == SettingKey.DefaultSupplier).FirstOrDefault().AppValue;
                ddCustomer.SelectedValue = SettingData.Where(x => x.AppKey == SettingKey.WalkingCustomer).FirstOrDefault().AppValue;

            }

        }
        private void ck_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Data = Db.Setting.GetAll().ToList();
                Data.Where(x => x.AppKey == SettingKey.PrintInvoice).FirstOrDefault().AppValue = ckPrintInvoice.IsChecked.ToString();
                Data.Where(x => x.AppKey == SettingKey.PrintLogo).FirstOrDefault().AppValue = ckPrintLogo.IsChecked.ToString();
                Data.Where(x => x.AppKey == SettingKey.PrintReport).FirstOrDefault().AppValue = ckPrintReport.IsChecked.ToString();
                Data.Where(x => x.AppKey == SettingKey.PrintConfirmation).FirstOrDefault().AppValue = ckPrintConfirmation.IsChecked.ToString();
                Data.Where(x => x.AppKey == SettingKey.ExpiryAlert).FirstOrDefault().AppValue = ckExpiryAlert.IsChecked.ToString();

                if (txtShopName.Text!= "") 
                {
                    Data.Where(x => x.AppKey == SettingKey.ShopName).FirstOrDefault().AppValue = txtShopName.Text;
                }
                if (txtHeader.Text != "") 
                {
                    Data.Where(x => x.AppKey == SettingKey.ReportHeader).FirstOrDefault().AppValue = txtHeader.Text;
                }
                if (txtFooter.Text != "") 
                {
                    Data.Where(x => x.AppKey == SettingKey.ReportFooter).FirstOrDefault().AppValue = txtFooter.Text;
                }
                if (txtMaxNoPrints.Text != "")
                {
                    Data.Where(x => x.AppKey == SettingKey.MaxNoPrints).FirstOrDefault().AppValue = txtMaxNoPrints.Text;
                }
                if (txtExpiryAlertMonths.Text != "")
                {
                    Data.Where(x => x.AppKey == SettingKey.ExpiryAlertMonths).FirstOrDefault().AppValue = txtExpiryAlertMonths.Text;
                }
                if (ddInvoicePrinter.SelectedItem != null)
                {
                    Data.Where(x => x.AppKey == SettingKey.InvoicePrinter).FirstOrDefault().AppValue = ddInvoicePrinter.Text;
                }
                if (ddReportPrinter.SelectedItem != null)
                {
                    Data.Where(x => x.AppKey == SettingKey.ReportPrinter).FirstOrDefault().AppValue = ddReportPrinter.Text;
                }
                if (ddCurrency.SelectedItem != null)
                {
                    Data.Where(x => x.AppKey == SettingKey.Currency).FirstOrDefault().AppValue = ddCurrency.SelectedValue.ToString() ;
                }
                if (ddSupplier.SelectedItem != null)
                {
                    Data.Where(x => x.AppKey == SettingKey.DefaultSupplier).FirstOrDefault().AppValue = ddSupplier.SelectedValue.ToString();
                }
                if (ddCustomer.SelectedItem != null)
                {
                    Data.Where(x => x.AppKey == SettingKey.WalkingCustomer).FirstOrDefault().AppValue = ddCustomer.SelectedValue.ToString();
                }
                //if (!string.IsNullOrEmpty(UserImage.Source?.ToString()))
                //{
                //    AddEmployee.Image = UserImage.Source?.ToString();
                //}
                Db.Setting.Save();
                ActiveSession.Setting = Data;
            }
            EZYPOS.View.MessageBox.ShowCustom("Settings Saved Successfully !", "Message", "Ok");
        }
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            //dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                UserImage.Source = bitmap;
                string imgDirPath = Environment.CurrentDirectory + @"\Assets\";
                string ImgFullPath = imgDirPath + "logo.png";
                UserImage.Source = null;
                if (File.Exists(ImgFullPath))
                {
                    File.Delete(ImgFullPath);
                }
                
                SaveImage(bitmap, ImgFullPath);
               
                SetImage(ImgFullPath);
            }
        }

        private void SaveImage(BitmapImage image, string filePath)
        {
            try
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));

                using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                {
                    encoder.Save(fileStream);
                }
            }
            catch(Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Close All Screens Except Settings","Critical","Ok");
            }

        }


        private void SetImage(string ImagePath, string UserName = "Selected logo")
        {
            if (File.Exists(ImagePath))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath);
                bitmap.EndInit();
                var myImage = bitmap.Clone();
                UserImage.Source = myImage;
                ImageSelector.Content = UserName;
            }
        }
    }
}
