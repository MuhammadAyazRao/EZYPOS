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
    /// Interaction logic for UserControlSupplierCRNoteList.xaml
    /// </summary>
    public partial class UserControlSupplierCRNoteList : UserControl
    {
        List<CustomerDRNoteDTO> myList { get; set; }
        Pager<CustomerDRNoteDTO> Pager = new Helper.Pager<CustomerDRNoteDTO>();
        public UserControlSupplierCRNoteList()
        {
            InitializeComponent();
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                var Suppliers = DB.Supplier.GetAll().OrderBy(x => x.Name).ToList().Select(x => new { Name = x.Name, Id = x.Id }).ToList();
                Suppliers.Insert(0, new { Name = "All", Id = 0 });
                DDSupplier.ItemsSource = Suppliers;
            }
            this.Language = System.Windows.Markup.XmlLanguage.GetLanguage(HelperMethods.GetCurrency());
            Refresh();
        }


        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                if (DDSupplier.SelectedValue != null)
                {
                    if (DDSupplier.SelectedValue.ToString() != "0")
                    {
                        int SupplierId = Convert.ToInt32(DDSupplier.SelectedValue);
                        myList = DB.SupplierCRNote.GetAll().Where(x => x.SupplierId == SupplierId).Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, CustomerName = x.Supplier.Name, }).ToList();
                    }
                    else
                    {
                        myList = DB.SupplierCRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, CustomerName = x.Supplier.Name, }).ToList();

                    }
                }

                else
                {
                    myList = DB.SupplierCRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, CustomerName = x.Supplier.Name, }).ToList();
                }

                ResetPaging(myList);
            }
        }

        private void SupplierPaymentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ResetPaging(List<CustomerDRNoteDTO> ListTopagenate)
        {
            SupplierCRNoteGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSupplierCRNoteCrud());
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
                        if (DDSupplier.SelectedValue != null)
                        {
                            if (DDSupplier.SelectedValue.ToString() != "0")
                            {
                                int SupplierId = Convert.ToInt32(DDSupplier.SelectedValue);
                                myList = DB.SupplierCRNote.GetAll().Where(x => x.SupplierId == SupplierId).Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, CustomerName = x.Supplier.Name, }).ToList();
                            }
                            else
                            {
                                myList = DB.SupplierCRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, CustomerName = x.Supplier.Name, }).ToList();

                            }
                        }

                        else
                        {
                            myList = DB.SupplierCRNote.GetAll().Select(x => new CustomerDRNoteDTO { Id = x.Id, Amount = x.ReceiptAmount, Discription = x.Discription, TransactionDate = x.TransactionDate, ReceivedBy = x.PayedByNavigation == null ? null : x.PayedByNavigation.UserName, CustomerName = x.Supplier.Name, }).ToList();
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
                        if (t.Name == "GridPayedBy")
                        {
                            myList = myList.Where(x => x.ReceivedBy.ToUpper().Contains(filter.ToUpper())).ToList();
                        }
                        if (t.Name == "GridSuppplier")
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
            SupplierCRNoteGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            SupplierCRNoteGrid.ItemsSource = Pager.Previous(myList);
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
            SupplierCRNoteGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SupplierCRNoteGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.CustomerDRNoteDTO CRDTO = (EZYPOS.DTO.CustomerDRNoteDTO)SupplierCRNoteGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSupplierCRNoteCrud(CRDTO));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete Record?", "Yes", "No");
            if (Isconfirm)
            {
                EZYPOS.DTO.CustomerDRNoteDTO CRDTO = (EZYPOS.DTO.CustomerDRNoteDTO)SupplierCRNoteGrid.SelectedItem;
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    DB.SupplierCRNote.Delete(CRDTO.Id);
                    DB.SupplierLead.Delete(DB.SupplierLead.GetAll().Where(x => x.TransactionType == Common.InvoiceType.SupplierDRNote && x.TransactionId == CRDTO.Id).FirstOrDefault().Id);
                    DB.SupplierCRNote.Save();
                    DB.SupplierLead.Save();
                }
                Refresh();
            }

        }
    }
}