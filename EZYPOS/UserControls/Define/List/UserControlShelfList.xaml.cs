using Common.Session;
using DAL.DBModel;
using EZYPOS.UserControls.Define.Crud;
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

namespace EZYPOS.UserControls.Define.List
{
    /// <summary>
    /// Interaction logic for UserControlShelfList.xaml
    /// </summary>
    public partial class UserControlShelfList : UserControl
    {
        public UserControlShelfList()
        {
            InitializeComponent();
            DG_GetData();
        }

        private void AddShelf_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlShelfCrud());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TblShelf shlf = (TblShelf)ShelfGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlShelfCrud(shlf));
        }

        void DG_GetData()
        {
            EPOSDBContext db = new EPOSDBContext();
            ShelfGrid.ItemsSource = db.TblShelves.ToList();
        }

    }
}
