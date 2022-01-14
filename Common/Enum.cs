using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    public enum MeasuringUnit
    { 
        KG=1,
        G=2
    }
    public static class InvoiceType
    {
        public static string SaleInvoice { get { return nameof(SaleInvoice); } }        
        public static string ReturnInvoice { get { return nameof(ReturnInvoice); } }
        public static string PurchaseInvoice { get { return nameof(PurchaseInvoice); } }
    }

    public static class ScreenType
    {
        public static string Sale { get { return nameof(Sale); } }
        public static string Return { get { return nameof(Return); } }
        public static string Purchase { get { return nameof(Purchase); } }
    }
    public static class OrderEnums
    {
        public static class PaymentType
        {
            public static string CASH { get { return nameof(CASH); } }
            public static string CREDIT { get { return nameof(CREDIT); } }          
        }
        public static class status
        {
            public static string cooking { get { return nameof(cooking); } }
            public static string hide { get { return nameof(hide); } }
            public static string complete { get { return nameof(complete); } }
            public static string delivered { get { return nameof(delivered); } }
            public static string cancel { get { return nameof(cancel); } }
        }

        public static class type
        {
            public static string offline { get { return nameof(offline); } }
            public static string epos { get { return nameof(epos); } }
        }

        public static class IsMobile
        {
            public static string yes { get { return nameof(yes); } }
            public static string no { get { return nameof(no); } }
        }

        public static class OrderStatus
        {
            public static string True { get { return nameof(True).ToLower(); } }
            public static string False { get { return nameof(False).ToLower(); } }
        }

        public static class PaymentStatus
        {
            public static string pending { get { return nameof(pending); } }
            public static string completed { get { return nameof(completed); } }
            public static string refunded { get { return nameof(refunded); } }
        }

        public static class deliveryType
        {
            public static string delivery { get { return nameof(delivery); } }
            public static string collected { get { return nameof(collected); } }
            public static string waiting { get { return nameof(waiting); } }
            public static string eatinn { get { return nameof(eatinn); } }
        }

        public static class order_format_status
        {
            public static string fresh { get { return nameof(fresh); } }
            public static string old { get { return nameof(old); } }
        }

        public static class Is_Preorder
        {
            public static string yes { get { return nameof(yes); } }
            public static string no { get { return nameof(no); } }
        }

        public static class PrintDelay
        {
            public static string yes { get { return nameof(yes); } }
            public static string no { get { return nameof(no); } }
        }

        public static class eatinn_payment_status
        {
            public static string pending { get { return nameof(pending); } }
            public static string completed { get { return nameof(completed); } }
        }

        public static class Screen_Types
        {
            public static string NoScreen { get { return nameof(NoScreen); } }
            public static string Backscreen { get { return nameof(Backscreen); } }
            public static string MonitorScreen { get { return nameof(MonitorScreen); } }
        }
    }
}
