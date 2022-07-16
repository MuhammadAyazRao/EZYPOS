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
    /// Interaction logic for UserControlCustomerDRNoteList.xaml
    /// </summary>
    public partial class UserControlCustomerDRNoteList : UserControl
    {
        List<CustomerDRNoteDTO> myList { get; set; }
        Pager<CustomerDRNoteDTO> Pager = new Helper.Pager<CustomerDRNoteDTO>();
        public UserControlCustomerDRNoteList()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Customers = DB.Customers.GetAll().OrderBy(x => x.Name).ToList().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                Customers.Insert(0, new { Name = "All", Id = 0 });
                DDCustomer.ItemsSource = Customers;
            }
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(HelperMethods.GetCurrency());
            Refresh();
        }


        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if(DDCustomer.SelectedValue != null )
                {
                    if (DDCustomer.SelectedValue.ToString() != "0")
                    {
                        int CustomerId = Convert.ToInt32(DDCustomer.SelectedValue);
                        myList = DB.CustomerDRNote.GetAll().Where(x => x.CustomerId == CustomerId).Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.UserName, CustomerName = x.Customer.Name, }).ToList();
                    }
                    else
                    {
                        myList = DB.CustomerDRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.UserName, CustomerName = x.Customer.Name, }).ToList();

                    }
                }
                
                else
                {
                    myList = DB.CustomerDRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = Convert.ToInt32(x.ReceiptAmount), Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.UserName, CustomerName = x.Customer.Name, }).ToList();
                }

                ResetPaging(myList);
            }
        }

        private void SupplierPaymentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ResetPaging(List<CustomerDRNoteDTO> ListTopagenate)
        {
            CustomerDRNoteGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCustomerDRNoteCrud());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

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
                        if (DDCustomer.SelectedValue != null)
                        {
                            if (DDCustomer.SelectedValue.ToString() != "0")
                            {
                                int CustomerId = Convert.ToInt32(DDCustomer.SelectedValue);
                                myList = DB.CustomerDRNote.GetAll().Where(x => x.CustomerId == CustomerId).Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.UserName, CustomerName = x.Customer.Name, }).ToList();
                            }
                            else
                            {
                                myList = DB.CustomerDRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.UserName, CustomerName = x.Customer.Name, }).ToList();

                            }
                        }

                        else
                        {
                            myList = DB.CustomerDRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.ReceivedByNavigation == null ? null : x.ReceivedByNavigation.UserName, CustomerName = x.Customer.Name, }).ToList();
                        }
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
                            myList = myList.Where(x => x.ReceivedBy.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridCustomer")
                        {
                            myList = myList.Where(x => x.CustomerName.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        ResetPaging(myList);
                    }

                }
            }
        }
        private void NumberDecimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            CustomerDRNoteGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            CustomerDRNoteGrid.ItemsSource = Pager.Previous(myList);
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
            CustomerDRNoteGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            CustomerDRNoteGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.CustomerDRNoteDTO CRDTO = (EZYPOS.DTO.CustomerDRNoteDTO)CustomerDRNoteGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlCustomerDRNoteCrud(CRDTO));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete Record?", "Yes", "No");
            if (Isconfirm)
            {
                EZYPOS.DTO.CustomerDRNoteDTO CRDTO = (EZYPOS.DTO.CustomerDRNoteDTO)CustomerDRNoteGrid.SelectedItem;
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    DB.CustomerDRNote.Delete(CRDTO.Id);
                    DB.CustomerLead.Delete(DB.CustomerLead.GetAll().Where(x => x.TransactionType == Common.InvoiceType.CustomerDrNote && x.TransactionId == CRDTO.Id).FirstOrDefault().Id);
                    DB.CustomerDRNote.Save();
                    DB.CustomerLead.Save();
                }
                Refresh();
            }
            
        }
    }
}