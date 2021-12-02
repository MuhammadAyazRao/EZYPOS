using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
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

namespace EZYPOS.UserControls.Transaction
{
    /// <summary>
    /// Interaction logic for SupplierPaymentList.xaml
    /// </summary>
    public partial class SupplierPaymentList : UserControl
    {
        List<SupplierPaymentDTO> myList { get; set; }
        Pager<SupplierPaymentDTO> Pager = new Helper.Pager<SupplierPaymentDTO>();
        public SupplierPaymentList()
        {
            InitializeComponent();
            Refresh();
        }
        

        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.SupplierPayment.GetAll().Select(x => new SupplierPaymentDTO { Id = x.Id, Amount = Convert.ToInt32(x.Amount), Discription=x.Discription, TransactionDate=x.TransactionDate, PayedBy = x.PayedByNavigation==null? null: x.PayedByNavigation.Name, Supplier = x.SupplierNavigation ==null?null : x.SupplierNavigation.Name,}).ToList();
                ResetPaging(myList);
            }
        }

        private void SupplierPaymentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ResetPaging(List<SupplierPaymentDTO> ListTopagenate)
        {
            SupplierPaymentGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSupplierPayment());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
                {
                    myList = DB.SupplierPayment.GetAll().Select(x => new SupplierPaymentDTO { Id = x.Id, Amount = Convert.ToInt32(x.Amount), Discription = x.Discription, TransactionDate = x.TransactionDate, PayedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.Name, Supplier = x.SupplierNavigation == null ? null : x.SupplierNavigation.Name, }).ToList();
                }
                else
                {
                    DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
                    DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
                    myList = DB.SupplierPayment.GetAll().Where(x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate).Select(x => new SupplierPaymentDTO { Id = x.Id, Amount = Convert.ToInt32(x.Amount), Discription = x.Discription, TransactionDate = x.TransactionDate, PayedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.Name, Supplier = x.SupplierNavigation == null ? null : x.SupplierNavigation.Name, }).ToList();
                }

                ResetPaging(myList);

            }
        }

        private void Id_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            SupplierPaymentGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            SupplierPaymentGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)  //I couldn't get this function to update in place (if the grid showed 20 and I selected 100 it would jump to 200)
        {                                                                                          //So instead I had it call the First function and that does an acceptable job.
                                                                                                   // numberOfRecPerPage = Convert.ToInt32(NumberOfRecords.SelectedItem);
                                                                                                   //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();            //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView;
                                                                                                   //PageInfo.Content = PageNumberDisplay();
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            SupplierPaymentGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SupplierPaymentGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.SupplierPaymentDTO SupplierPaymentDTO = (EZYPOS.DTO.SupplierPaymentDTO)SupplierPaymentGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSupplierPayment(SupplierPaymentDTO));
        }
    }
}
