using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.Helper
{
    class Constants
    {
        public static string FontFamily = "Verdana";
        public static string CurrencySymbol = "£";
        public static int LabelPrintHeight = 94; //94
        public static int LabelPrintWidth = 288; //288
        public static string Stripekey = "sk_test_pcw8sFas7RNEdD2x2ddMur7X";
        public static string StripeCurrency = "GBP";
        public static string WaitingLogopath = @"\logo\waiting.gif";
        public static string RestaurantLogopath = @"\Assets\logo.png";
        public static string NewOnlineOrder = "https://clickeatrepeat.com/api/partner_api/all_new_orders";
        public static string DriverScreenMapURL = "https://www.google.co.in/maps/dir/";
        public static string GeoCodeGoogleURL = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        public static string GeoCodeGoogleAPIKey = "AIzaSyBfAjpNIQIBqtgJqXuM5awva_iHoA3eA7o";
        public static string InternetTesting = "https://www.google.com/";
        public static string SyncAppDataURL = "https://clickeatrepeat.com/api-sync/get_db/tables";
        public static string DatabaseQuery = "https://epos-tech.com/api-sync/get_db/queries_by_version";
        public static string PushCustomerDataURL = "http://clickeatrepeat.com/api-sync/import_data/customers";
       
        public static string Accept_Reject_Online_Order = "https://clickeatrepeat.com/api/partner_api/accept_reject_order";
        public static string Customertoken = "https://eatandrepeat.co.uk/api/customer/register_get_customerToken";
        public static string PushStripeorder = "https://eatandrepeat.co.uk/api/cart_new/save_order";
       

        public enum OrderType
        {
            collected,
            waiting,
            delivery,
            online,
            eatinn

        }

    }
}
