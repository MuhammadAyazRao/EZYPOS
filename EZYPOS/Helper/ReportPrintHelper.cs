using Common;
using Common.Session;
using DAL.DBMODEL;
using EZYPOS.DTO.ReportsDTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.Helper
{
    public class ReportPrintHelper
    {
        static string exePath = Directory.GetCurrentDirectory();
        static string imagePath = new Uri(exePath + Constants.Logopath).AbsoluteUri;
        //Method for 3 Columns
        public static void PrintCOL3Report(ref ReportViewer ReportViewer, string ReportName, string HeaderA, string HeaderB, string HeaderC, string Description, List<GenericCOL6DTO> RptData)
        {
            var Rpt_print = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.PrintReport).FirstOrDefault().AppValue;

            if (Rpt_print.ToLower() == "true")
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "GenericCOL3DataSet";
                rds.Value = RptData;
                ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL3Report.rdlc";
                ReportViewer.LocalReport.DataSources.Add(rds);
                ReportViewer.LocalReport.EnableExternalImages = true;
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ImagePath", imagePath));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", ReportName));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", HeaderA));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", HeaderB));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", HeaderC));
                string PrintDate = "Printed On: " + DateTime.Now.ToString("MM/dd/yyyy");
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDescription", Description));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("PrintDate", PrintDate));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportHeader).FirstOrDefault().AppValue));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("FooterDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportFooter).FirstOrDefault().AppValue));
                ReportViewer.RefreshReport();
                ReportViewer.LocalReport.Print();
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Switch On Report Print", "Information", "Ok");
            }
        }
        //Method for 4 Columns
        public static void PrintCOL4Report(ref ReportViewer ReportViewer, string ReportName, string HeaderA, string HeaderB, string HeaderC, string HeaderD, string Description, List<GenericCOL6DTO> RptData)
        {
            var Rpt_print = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.PrintReport).FirstOrDefault().AppValue;

            if (Rpt_print.ToLower() == "true")
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "GenericCOL4DataSet";
                rds.Value = RptData;
                ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL4Report.rdlc";
                ReportViewer.LocalReport.DataSources.Add(rds);
                ReportViewer.LocalReport.EnableExternalImages = true;
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ImagePath", imagePath));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", ReportName));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", HeaderA));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", HeaderB));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", HeaderC));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderD", HeaderD));
                string PrintDate = "Printed On: " + DateTime.Now.ToString("MM/dd/yyyy");
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDescription", Description));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("PrintDate", PrintDate));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportHeader).FirstOrDefault().AppValue));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("FooterDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportFooter).FirstOrDefault().AppValue));
                ReportViewer.RefreshReport();
                ReportViewer.LocalReport.Print();
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Switch On Report Print", "Information", "Ok");
            }
        }
        //Method for 5 Columns
        public static void PrintCOL5Report(ref ReportViewer ReportViewer, string ReportName, string HeaderA, string HeaderB, string HeaderC, string HeaderD, string HeaderE, string Description, List<GenericCOL6DTO> RptData)
        {
            var Rpt_print = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.PrintReport).FirstOrDefault().AppValue;

            if (Rpt_print.ToLower() == "true")
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "GenericCOL5DataSet";
                rds.Value = RptData;
                ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL5Report.rdlc";
                ReportViewer.LocalReport.DataSources.Add(rds);
                ReportViewer.LocalReport.EnableExternalImages = true;
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ImagePath", imagePath));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", ReportName));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", HeaderA));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", HeaderB));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", HeaderC));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderD", HeaderD));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderE", HeaderE));
                string PrintDate = "Printed On: " + DateTime.Now.ToString("MM/dd/yyyy");
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDescription", Description));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("PrintDate", PrintDate));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportHeader).FirstOrDefault().AppValue));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("FooterDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportFooter).FirstOrDefault().AppValue));
                ReportViewer.RefreshReport();
                ReportViewer.LocalReport.Print();
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Switch On Report Print", "Information", "Ok");
            }
        }

        //Method for 6 Columns
        public static void PrintCOL6Report(ref ReportViewer ReportViewer, string ReportName, string HeaderA, string HeaderB, string HeaderC, string HeaderD, string HeaderE, string HeaderF,string Description, List<GenericCOL6DTO> RptData)
        {
            var Rpt_print = ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.PrintReport).FirstOrDefault().AppValue;

            if (Rpt_print.ToLower() == "true")
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "GenericCOL6DataSet";
                rds.Value = RptData;
                ReportViewer.LocalReport.ReportPath = exePath + @"\RDLC\Generic\GenericCOL6Report.rdlc";
                ReportViewer.LocalReport.DataSources.Add(rds);
                ReportViewer.LocalReport.EnableExternalImages = true;
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ImagePath", imagePath));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportName", ReportName));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderA", HeaderA));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderB", HeaderB));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderC", HeaderC));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderD", HeaderD));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderE", HeaderE));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderF", HeaderF));
                string PrintDate = "Printed On: " + DateTime.Now.ToString("MM/dd/yyyy");
                ReportViewer.LocalReport.SetParameters(new ReportParameter("ReportDescription", Description));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("PrintDate", PrintDate));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("HeaderDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportHeader).FirstOrDefault().AppValue));
                ReportViewer.LocalReport.SetParameters(new ReportParameter("FooterDescription", ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.ReportFooter).FirstOrDefault().AppValue));
                ReportViewer.RefreshReport();
                ReportViewer.LocalReport.Print();
            }
            else
            {
                EZYPOS.View.MessageBox.ShowCustom("Please Switch On Report Print", "Information", "Ok");
            }
        }
    }
}
