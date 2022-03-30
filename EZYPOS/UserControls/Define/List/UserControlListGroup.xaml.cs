﻿using Common.Session;
using DAL.Repository;
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
    /// Interaction logic for UserControlListGroup.xaml
    /// </summary>
    public partial class UserControlListGroup : UserControl
    {
        List<DAL.DBMODEL.ProductGroup> myList { get; set; }
        Pager<DAL.DBMODEL.ProductGroup> Pager = new Helper.Pager<DAL.DBMODEL.ProductGroup>();

        public UserControlListGroup()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh(object sender = null)
        {
            using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
            {
                myList = DB.ProductGroup.GetAll().ToList();
                ResetPaging(myList);
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.CloseDisplayuserControlMethod(new UserControlGroupCrud());
        }
        //private void Search_Click(object sender, RoutedEventArgs e)
        //{

        //    using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
        //    {
        //        if (StartDate.SelectedDate == null && EndDate.SelectedDate == null)
        //        {
        //            myList = DB.ProductGroup.GetAll().ToList();
        //        }
        //        else
        //        {
        //            DateTime Sdate = StartDate.SelectedDate == null ? DateTime.Now : StartDate.SelectedDate.Value;
        //            DateTime Edate = EndDate.SelectedDate == null ? DateTime.Now : EndDate.SelectedDate.Value;
        //            // myList = DB.ProductCategory.GetAll().Where(x => x.Createdon >= Sdate && x.Createdon <= Edate).ToList();
        //        }

        //        GroupGrid.ItemsSource = myList;
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
                    if (filter == "")
                    {
                        myList = DB.ProductGroup.GetAll().ToList();
                    }
                    else
                    {

                        if (t.Name == "GridName")
                        {
                            myList = DB.ProductGroup.GetAll().Where(x => x.GroupName.ToUpper().Contains(filter.ToUpper())).ToList();

                        }
                    }
                    ResetPaging(myList);
                }
            }
        }
        private void ResetPaging(List<DAL.DBMODEL.ProductGroup> ListTopagenate)
        {
            GroupGrid.ItemsSource = Pager.First(ListTopagenate);
            PageInfo.Content = Pager.PageNumberDisplay(ListTopagenate);
        }
        private void Forward_Click(object sender, RoutedEventArgs e)    //For each of these you call the direction you want and pass in the List and ComboBox output
        {                                                               //and use the above function to output the Record number to the Label
            GroupGrid.ItemsSource = Pager.Next(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
           GroupGrid.ItemsSource = Pager.Previous(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void First_Click(object sender, RoutedEventArgs e)
        {
            GroupGrid.ItemsSource = Pager.First(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }

        private void Last_Click(object sender, RoutedEventArgs e)
        {
            GroupGrid.ItemsSource = Pager.Last(myList);
            PageInfo.Content = Pager.PageNumberDisplay(myList);
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBMODEL.ProductGroup ProductGroup = (DAL.DBMODEL.ProductGroup)GroupGrid.SelectedItem;
            ActiveSession.CloseDisplayuserControlMethod(new UserControlGroupCrud(ProductGroup));
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DAL.DBMODEL.ProductGroup ProductGroup = (DAL.DBMODEL.ProductGroup)GroupGrid.SelectedItem;
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete This Record?", "Yes", "No");
            if (Isconfirm)
            {
                using (UnitOfWork DB = new UnitOfWork(new DAL.DBMODEL.EPOSDBContext()))
                {
                    try
                    {
                        DB.ProductGroup.Delete(ProductGroup.Id);
                        DB.ProductGroup.Save();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deleted Successfully", "Status", "OK");
                        Refresh();
                    }
                    catch
                    {
                        EZYPOS.View.MessageBox.ShowCustom("Selected Group Can't be Deleted because its being used", "Status", "OK");
                    }

                }
            }

        }
    }
}
