using DAL.DBModel;
using DAL.Repository;
using DAL.IRepository;
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
using DAL.DBMODEL;

namespace EZYPOS.UserControls.Define.Crud
{
    /// <summary>
    /// Interaction logic for UserControlShelfCrud.xaml
    /// </summary>
    public partial class UserControlShelfCrud : UserControl
    {
        public UserControlShelfCrud(TblShelf shlf = null)
        {
            InitializeComponent();
            RefreshPage();
            if(shlf != null)
            {
                InitializePage(shlf);
            }
        }
        private void InitializePage(TblShelf shlf)
        {
            Delete.IsEnabled = true;
            Update.IsEnabled = true;
            Save.IsEnabled = false;
            using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
            {
                var shelfData = Db.Shelf.GetAll().Where(x=> x.Id == shlf.Id).FirstOrDefault();
                if (!string.IsNullOrEmpty(shelfData?.ShelfName))
                {
                    txtShelfName.Text = shelfData?.ShelfName;
                    txtShelfName.Foreground = Brushes.Black;
                    txtShelfCode.Text = shelfData?.ShelfCode;
                    txtShelfCode.Foreground = Brushes.Black;
                }
                txtId.Text = shelfData.Id.ToString();
            }

        }
        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;

            txtShelfName.Text = "Shelf Name";
            txtShelfName.Foreground = Brushes.Gray;
            txtShelfCode.Text = "Shelf Code";
            txtShelfCode.Foreground = Brushes.Gray;
            txtId.Text = "";

        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtShelfName.Text) || txtShelfName.Text == "Shelf Name")
            {
                EZYPOS.View.MessageBox.ShowCustom("Shelf Name is Required", "Error", "Ok");
                return false;
            }
            if(string.IsNullOrEmpty(txtShelfCode.Text) || txtShelfCode.Text == "Shelf Code")
            {
                EZYPOS.View.MessageBox.ShowCustom("Shelf Code is Required", "Error", "Ok");
                return false;
            }
            else return true;
        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch(tb.Text)
            {
                case "Shelf Name":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;
                case "Shelf Code":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;

            }
        }

        
        
        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb = sender as  TextBox;
            switch (tb.Name)
            {
                case "txtShelfName":

                    if (tb.Text == string.Empty)
                {
                tb.Text = "Shelf Name";
                tb.Foreground = Brushes.Gray;
                }
                break;
                case "txtShelfCode":
                    if(tb.Text == string.Empty)
                    {
                        tb.Text = "Shelf Code";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;
            }
            
        }
        
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            bool isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do You Want to Update Record", "Yes", "No");
            if (isconfirm)
            {
                if (Validate())
                {
                    using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
                    {
                        int id = Convert.ToInt32(txtId.Text);
                        var sh = uw.Shelf.Get(id);
                        sh.ShelfName = txtShelfName.Text;
                        sh.ShelfCode = txtShelfCode.Text;
                        uw.Shelf.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Your Record Updated Succesfully", "Status", "OK");
                        RefreshPage();
                    }
                }
                
                 
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using(UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
            {
                uw.Shelf.Delete(Convert.ToInt32(txtId.Text));
                uw.Complete();
                EZYPOS.View.MessageBox.ShowCustom("Record Deleted Succesfully", "Status", "Ok");
            }
            RefreshPage();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do You Want To Save Record", "Yes", "No");
            if (isconfirm)
            {
                if (Validate())
                { 
                    using (UnitOfWork uw = new UnitOfWork(new EPOSDBContext()))
                    {
                        TblShelf ts = new TblShelf();
                        ts.ShelfName = txtShelfName.Text;
                        ts.ShelfCode = txtShelfCode.Text;
                        uw.Shelf.Add(ts);
                        uw.Shelf.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Saved Succesfully", "Status", "OK");
                        RefreshPage();
                    }
                }
                
            }
            
            
        }
    }
}
