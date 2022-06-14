using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
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
using System.Windows.Shapes;

namespace EZYPOS.View
{
    /// <summary>
    /// Interaction logic for StartSession.xaml
    /// </summary>
    public partial class SessionScreen : Window
    {
        public string ScreenType { get; set; }
        public SessionScreen(string screenType)
        {
            ScreenType = screenType;
            InitializeComponent();
            if (ScreenType == "Start")
            {
                lblTitle.Content = "Please Start Session";
                btnSave.Content = "Start";
            }
            else if (ScreenType == "End")
            {
                lblTitle.Content = "End Session";
                btnSave.Content = "End";
            }
        }
        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { btnSave_Click(null, null); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn != null)
                {
                    if (lblPin.Content.ToString() == "0")
                    {
                        lblPin.Content = (string)btn.Content;
                    }
                    else
                    {
                        lblPin.Content += (string)btn.Content;
                    }

                }
            }
            catch (Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok");
            }
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((string)lblPin.Content != string.Empty))
                {
                    lblPin.Content = lblPin.Content.ToString().Remove(lblPin.Content.ToString().Length - 1);
                }
            }
            catch (Exception exp)
            { EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "ok"); }
        }

        private void ClearPin()
        {
            lblPin.Content = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearPin();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if ((string)lblPin.Content != "0")
            {
                using (UnitOfWork Db = new UnitOfWork(new EPOSDBContext()))
                {
                    if (ScreenType == "Start")
                    {
                        CashSummary CS = new CashSummary();
                        CS.StartAmount = Convert.ToDecimal(lblPin.Content);
                        CS.StartDate = DateTime.Now;
                        CS.StartedBy = ActiveSession.ActiveUserName;
                        CS.Posid = ActiveSession.POSId;
                        CS.IsActive = true;
                        Db.CashSummary.Add(CS);
                        Db.CashSummary.Save();
                        this.Close();
                    }
                    else if (ScreenType == "End")
                    {
                        var isconfirm = EZYPOS.View.MessageYesNo.ShowCustom("Confirmation", "Do You Want to End Session !", "Yes", "NO");
                        if(isconfirm)
                        {
                            var StartedSession = Db.CashSummary.GetAll().Where(x => x.IsActive == true && x.Posid == ActiveSession.POSId).FirstOrDefault();
                            if (StartedSession != null)
                            {
                                if((string)lblPin.Content != "0")
                                {
                                    StartedSession.EndAmount = Convert.ToDecimal(lblPin.Content);
                                    StartedSession.EndedBy = ActiveSession.ActiveUserName;
                                    StartedSession.EndDate = DateTime.Now;
                                    StartedSession.IsActive = false;
                                    Db.CashSummary.Save();
                                    this.Close();
                                    ActiveSession.CloseDisplayuserControlMethod(null);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if(ScreenType == "Start")
            {
                ActiveSession.CloseDisplayuserControlMethod(null);
                this.Close();
            }
            else if (ScreenType == "End")
            {
                this.Close();
            }

        }

        private void DotClick(object sender, RoutedEventArgs e)
        {
            if (lblPin.Content.ToString().Contains("."))
            {
                EZYPOS.View.MessageBox.ShowCustom("Mathematical Expression can not have two dots.", "Mathematical Error", "ok");
            }
            else if (lblPin.Content.ToString() == "0" || lblPin.Content.ToString() == "")
            {
                lblPin.Content = "0.";
            }
            else if ((string)lblPin.Content != string.Empty)
            {
                lblPin.Content = lblPin.Content.ToString() + ".";
            }
        }
    }
}
