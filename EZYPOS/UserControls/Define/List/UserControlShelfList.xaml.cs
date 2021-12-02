using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using EZYPOS.Helper;
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
        List<DAL.DBMODEL.TblShelf> myList { get; set; }
        Pager<DAL.DBMODEL.TblShelf> Pager = new Helper.Pager<DAL.DBMODEL.TblShelf>();
        public UserControlShelfList()
        {
            InitializeComponent();
            Refresh();
            
        }

        private void AddShelf_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlShelfCrud());
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.Shelf.GetAll().ToList();
                ShelfGrid.ItemsSource = myList;
                ResetPaging(myList);
            }
        }
        

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ResetPaging(List<DAL.DBMODEL.TblShelf> ListTopagenate)
        {
            ShelfGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            ShelfGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            ShelfGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void First_Click(object sender, RoutedEventArgs e)
        {
            ShelfGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            ShelfGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TblShelf shlf = (TblShelf)ShelfGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlShelfCrud(shlf));
        }

    }
}
