using DAL.IRepository;
using DAL.Repository;
using EZYPOS.DBModels;
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
    /// Interaction logic for Pinverification.xaml
    /// </summary>
    public partial class Pinverification : Window
    {
        public Pinverification()
        {
            InitializeComponent();
        }

        public string pin { get; set; }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {  
            if (!string.IsNullOrEmpty(lblPin.Password))
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {


                    var user = DB.shopSettings.GetAll().Where(x => x.Pin == Convert.ToInt32(lblPin.Password)).FirstOrDefault();
                    if (user != null)
                    {
                        this.DialogResult = true;
                        Close();
                    }
                    else
                    {
                        lblErrMsg.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Password is Empty", "Error", "ok");
            }

        }

        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { btnAdd_Click(null, null); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    if (lblPin.Password.ToString() == "0")
                    {
                        lblPin.Password = (string)btn.Content;
                        pin = btn.Content.ToString();
                    }
                    else
                    {
                        lblPin.Password += (string)btn.Content;
                        pin += (string)btn.Content;
                    }

                }
            }
            catch (Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok");
            }
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((string)lblPin.Password != string.Empty) && (pin != string.Empty))
                {
                    lblPin.Password = lblPin.Password.ToString().Remove(lblPin.Password.ToString().Length - 1);
                    pin = pin.Remove(pin.Length - 1);

                }
            }
            catch (Exception exp)
            { EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok"); }
        }

        private void ClearPin()
        {
            lblPin.Password = "";
            pin = 1.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearPin();
        }
    }
}
