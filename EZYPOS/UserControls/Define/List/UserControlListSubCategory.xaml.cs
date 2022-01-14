using Common.Session;
using DAL.Repository;
using EZYPOS.DTO;
using EZYPOS.Helper;
using EZYPOS.Helper.Session;
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
    /// Interaction logic for UserControlListSubCategory.xaml
    /// </summary>
    public partial class UserControlListSubCategory : UserControl
    {
        List<SubCategoryDTO> myList { get; set; }
        Pager<SubCategoryDTO> Pager = new Helper.Pager<SubCategoryDTO>();
        public UserControlListSubCategory()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {

            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.ProductSubcategory.GetAll().Select(x => new SubCategoryDTO { Id = x.Id, SubcategoryName = x.SubcategoryName, CategoryName = x.Category.Name == null ? null : x.Category.Name }).ToList();
                //customerGrid.ItemsSource = First(myList, numberOfRecPerPage).DefaultView; //Fill a DataTable with the First set based on the numberOfRecPerPage                 
                ResetPaging(myList);
            }
        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {

            EZYPOS.DTO.SubCategoryDTO Subcategory = (EZYPOS.DTO.SubCategoryDTO)SubCategoryGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSubCategoryCrud(Subcategory));
            //ActiveSession.NavigateToSwitchScreen(new UserControlCustomerCrud(CustomerObj));

        }
        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
        //    {
               
        //        if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
        //        {
        //            myList = DB.ProductSubcategory.GetAll().Select(x => new SubCategoryDTO { Id = x.Id, SubcategoryName = x.SubcategoryName, CategoryName = x.Category.Name == null ? null : x.Category.Name }).ToList();
        //        }
        //        else
        //        {
        //            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
        //            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
        //            myList = DB.ProductSubcategory.GetAll().Select(x => new SubCategoryDTO { Id = x.Id, SubcategoryName = x.SubcategoryName, CategoryName = x.Category.Name == null ? null : x.Category.Name }).ToList();
        //        }
        //        SubCategoryGrid.ItemsSource = myList;
        //        ResetPaging(myList);
        //    }

        //}
        private void GridName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string filter = t.Text;
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    myList = DB.ProductSubcategory.GetAll().Select(x => new SubCategoryDTO { Id = x.Id, SubcategoryName = x.SubcategoryName, CategoryName = x.Category.Name == null ? null : x.Category.Name }).ToList();

                    if (filter == "")
                    {
                        ResetPaging(myList);
                    }
                    else
                    {

                        if (t.Name == "GridName")
                        {

                            ResetPaging(myList.Where(x => x.SubcategoryName.ToUpper().Contains(filter.ToUpper())).ToList());
                        }
                        if (t.Name == "Category")
                        {

                            ResetPaging(myList.Where(x => x.CategoryName.ToUpper().Contains(filter.ToUpper())).ToList());
                        }

                    }

                }
            }

        }
        private void ResetPaging(List<SubCategoryDTO> ListTopagenate)
        {
            SubCategoryGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void btnAddSubcategory_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlSubCategoryCrud());
        }

       


        #region Pagination

        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            SubCategoryGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            SubCategoryGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        

        private void First_Click(object sender, RoutedEventArgs e)
        {
            SubCategoryGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            SubCategoryGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        #endregion

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            EZYPOS.DTO.SubCategoryDTO Subcategory = (EZYPOS.DTO.SubCategoryDTO)SubCategoryGrid.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This Record?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    try
                    {
                        DB.ProductSubcategory.Delete(Subcategory.Id);
                        DB.ProductSubcategory.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
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
