﻿using DAL.Repository;
using EZYPOS.DBModels;
using EZYPOS.Helper.Session;
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

namespace EZYPOS.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlExpenceHeadCrud.xaml
    /// </summary>
    public partial class UserControlExpenceHeadCrud : UserControl
    {
        public UserControlExpenceHeadCrud(DAL.DBModel.ExpenceType ExpenceType = null)
        {
            InitializeComponent();
            RefreshPage();

            if (ExpenceType != null)
            { InitializePage(ExpenceType); }
        }
        private void InitializePage(DAL.DBModel.ExpenceType ExpenceType)
        {
            using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
            {
                var Expencedata = Db.ExpenceType.Get(ExpenceType.Id);
                if (!string.IsNullOrEmpty(Expencedata?.ExpenceName))
                {
                    txtFName.Text = Expencedata?.ExpenceName;
                    txtFName.Foreground = Brushes.Black;
                }
                txtId.Text = Expencedata.Id.ToString();
            }

        }
        private void RefreshPage()
        {
            Delete.IsEnabled = false;
            Update.IsEnabled = false;
            Save.IsEnabled = true;

            txtFName.Text = "Name";
            txtFName.Foreground = Brushes.Gray;
            txtId.Text = "";

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.NavigateToSwitchScreen(new UserControlExpenceHeadCrud());
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirmed = EZYPOS.View.MessageYesNo.ShowCustom("Refresh", "Do you want to refresh page?", "Yes", "No");
            if (Isconfirmed)
            { RefreshPage(); }
        }

        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            //tb.Text = string.Empty;
            //tb.Foreground = Brushes.Black;
            switch (tb.Text)
            {
                case "Name":
                    tb.Text = string.Empty;
                    tb.Foreground = Brushes.Black;
                    break;

            }
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            switch (tb.Name)
            {
                case "txtFName":
                    if (tb.Text == string.Empty)
                    {
                        tb.Text = "Name";
                        tb.Foreground = Brushes.Gray;
                    }
                    break;


            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (txtId.Text != "" && txtId.Text != "0")
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                    {
                        var Expence = Db.ExpenceType.Get(Id);
                        if (Expence != null)
                        {
                            if (!string.IsNullOrEmpty(txtFName.Text))
                            {
                                Expence.ExpenceName = txtFName.Text;
                            }
                            Db.Complete();
                            EZYPOS.View.MessageBox.ShowCustom("Record Updated Successfully", "Status", "OK");
                            RefreshPage();
                        }
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Save Record?", "Yes", "No");
            if (Isconfirm)
            {
                if (Validate())
                {
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                    {
                        DAL.DBModel.ExpenceType Expence = new DAL.DBModel.ExpenceType();
                        Expence.ExpenceName = txtFName.Text;
                        Expence.Createdon = DateTime.Now;
                        Db.ExpenceType.Add(Expence);
                        Db.Complete();
                        EZYPOS.View.MessageBox.ShowCustom("Record Saved Successfully", "Status", "OK");
                        RefreshPage();
                    }
                }
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtFName.Text) || txtFName.Text == "Name")
            {
                EZYPOS.View.MessageBox.ShowCustom("Name is Required.", "Error", "OK");
                return false;
            }
            return true;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bool Isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do you want to Delete Record?", "Yes", "No");
            if (Isconfirm)
            {

                if (txtId.Text != "" && txtId.Text != "0")
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    using (UnitOfWork Db = new UnitOfWork(new DAL.DBModel.EPOSDBContext()))
                    {
                        Db.ExpenceType.Delete(Id);
                        Db.Complete();
                        EZYPOS.View.MessageBox.ShowCustom("Record Deteleted Successfully", "Status", "OK");
                    }
                    RefreshPage();
                }
            }
        }

    }
}
