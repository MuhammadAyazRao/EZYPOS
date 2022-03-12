using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using System;
using System.Collections.Generic;
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

namespace EZYPOS.UserControls.Transaction.Lists
{
    /// <summary>
    /// Interaction logic for UserControlCustomerReceiptList.xaml
    /// </summary>
    public partial class UserControlCustomerReceiptList : UserControl
    {
        List<CustomerReceiptDTO> myList { get; set; }
        Pager<CustomerReceiptDTO> Pager = new Helper.Pager<CustomerReceiptDTO>();
        public UserControlCustomerReceiptList()
        {
            InitializeComponent();
            Refresh();
        }


        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.CustomerReceipt.GetAll().Select(x => new CustomerReceiptDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, Employee = x.Employee == null ? null : x.Employee.UserName , Customer = x.Customer == null? null : x.Customer.Name }).ToList();
                ResetPaging(myList);
            }
        }

        private void SupplierPaymentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ResetPaging(List<CustomerReceiptDTO> ListTopagenate)
        {
            CustomerReceiptGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCutomerReceipt());
        }

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
        //    {
        //        if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
        //        {
        //           myList = DB.CustomerReceipt.GetAll().Select(x => new CustomerReceiptDTO { Id = x.Id, Amount = Convert.ToInt32(x.ReceiptAmount), Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.Name,}).ToList();
        //        }
        //        else
        //        {
        //            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
        //            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
        //            myList = DB.CustomerReceipt.GetAll().Where(x => x.TransactionDate >= Sdate && x.TransactionDate <= Edate).Select(x => new CustomerReceiptDTO { Id = x.Id, Amount = Convert.ToInt32(x.ReceiptAmount), Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.Name, }).ToList();
        //        }

        //        ResetPaging(myList);

        //    }
        //}

        private void Id_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    if (filter == "")
                    {
                        Refresh();
                    }
                    else
                    {
                        myList = DB.CustomerReceipt.GetAll().Select(x => new CustomerReceiptDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, Employee = x.Employee == null ? null : x.Employee.UserName, Customer = x.Customer == null ? null : x.Customer.Name }).ToList();
                        if (t.Name == "GridAmount")
                        {
                            myList = myList.Where(x => x.Amount.ToString().Contains(filter)).ToList();
                        }
                        if (t.Name == "GridDiscription")
                        {
                            myList = myList.Where(x => x.Discription.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridTdate")
                        {
                            myList = myList.Where(x => x.TransactionDate.ToString().Contains(filter)).ToList();
                        }
                        if (t.Name == "GridRecievedBy")
                        {
                            myList = myList.Where(x => x.Employee.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridCustomer")
                        {
                            myList = myList.Where(x => x.Customer.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        ResetPaging(myList);
                    }
                }
            }

        }

        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CustomerReceiptGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CustomerReceiptGrid.ItemsSource = Pager.Previous(myList);
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
            CustomerReceiptGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CustomerReceiptGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.CustomerReceiptDTO CRDTO = (EZYPOS.DTO.CustomerReceiptDTO)CustomerReceiptGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCutomerReceipt(CRDTO));
        }
        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberDecimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.CustomerReceiptDTO CRDTO = (EZYPOS.DTO.CustomerReceiptDTO)CustomerReceiptGrid.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This Record?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    try
                    {
                        DB.CustomerReceipt.Delete(CRDTO.Id);
                        DB.CustomerLead.Delete(DB.CustomerLead.GetAll().Where(x => x.TransactionType == Common.InvoiceType.CustomerReceipt && x.TransactionId == Convert.ToInt32(CRDTO.Id)).FirstOrDefault().Id);
                        DB.CustomerReceipt.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deleted Successfully", "Status", "OK");
                        Refresh();
                    }
                    catch
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Selected Record Can't be Deleted", "Status", "OK");
                    }

                }
            }
        }
    }
}
