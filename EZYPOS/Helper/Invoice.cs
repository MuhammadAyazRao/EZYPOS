using Common.DTO;
using Common.Session;
using EZYPOS.DTO;
using EZYPOS.Helper.Session;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EZYPOS.Helper
{
    

    public class Invoice
    {
       
        private Order order;

        public static FlowDocument GetFlowDocumentAsync(Order order)
        {
            FlowDocument flowDocument = null;
            try
            {
                string imgPath = Environment.CurrentDirectory;              


                double pageWidth = 288;

                flowDocument = new FlowDocument();
                flowDocument.PageWidth = pageWidth;
                flowDocument.PagePadding = new Thickness(10);
                flowDocument.FontFamily = new FontFamily(Constants.FontFamily);
                flowDocument.FontSize = 12;
                //flowDocument.FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
                //flowDocument.FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
                Paragraph p = new Paragraph();
                if (ActiveSession.PrintLogo)
                {

                    Image ReslogoImg = new Image();
                    ReslogoImg.Margin = new Thickness(0, 10, 0, 10);
                    ReslogoImg.HorizontalAlignment = HorizontalAlignment.Center;
                    ReslogoImg.Width = pageWidth;
                    ReslogoImg.Height = 120;

                    try
                    {
                        ReslogoImg.Source = new BitmapImage(new Uri(imgPath + Constants.Logopath));
                    }
                    catch (FileNotFoundException ex)
                    {
                        View.MessageBox.ShowCustom(ex.FileName + " Restaurant Logo not found.", "Invoice Error", "Ok");
                    }

                    p.Inlines.Add(ReslogoImg);
                }
                //----status----

               


                if (order.payment_status == "completed")
                {
                    TextBlock Paid = new TextBlock()
                    {
                        Text = "PAID",
                        Width = pageWidth,
                        Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0xd9, 0x53, 0x4f)),
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontWeight = FontWeights.Bold,
                        Height = 20,
                        FontSize = 20,
                    };
                    p.Inlines.Add(Paid);
                }

                flowDocument.Blocks.Add(p);

                //---Info Section------
                Grid infoGrid = new Grid();
                infoGrid.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left;
                infoGrid.FlowDirection = FlowDirection.LeftToRight;


                //if (order.Customer != null)
                //{
                //    TextBlock lblName = new TextBlock()
                //    {
                //        Text = order.Customer.bill_name + " " + order.Customer.bill_surname,
                //        HorizontalAlignment = HorizontalAlignment.Left,
                //        TextAlignment = TextAlignment.Left,
                //        Width = 120,
                //        Height = 20
                //    };
                //    infoGrid.Children.Add(lblName);

                //    TextBlock lblHouseNo = new TextBlock()
                //    {
                //        Text = order.Customer.bill_phone,
                //        HorizontalAlignment = HorizontalAlignment.Left,
                //        Height = 20,
                //        Width = 120,
                //        Margin = new Thickness(0, 25, 0, 0)
                //    };
                //    infoGrid.Children.Add(lblHouseNo);

                //    if (order.delivery_type.ToLower() != "collected")
                //    {
                //        lblHouseNo.Text = order.Customer.bill_door_num + " " + order.Customer.bill_street;

                //        TextBlock lblStreet = new TextBlock()
                //        {
                //            Text = order.Customer.bill_town,
                //            HorizontalAlignment = HorizontalAlignment.Left,
                //            Height = 20,
                //            Width = 120,
                //            Margin = new Thickness(0, 50, 0, 0)
                //        };

                //        TextBlock lblTown = new TextBlock()
                //        {
                //            Text = order.Customer.bill_zipcode,
                //            HorizontalAlignment = HorizontalAlignment.Left,
                //            Height = 20,
                //            Width = 120,
                //            Margin = new Thickness(0, 75, 0, 0)
                //        };

                //        TextBlock lblPost = new TextBlock()
                //        {
                //            Text = order.Customer.bill_phone,
                //            HorizontalAlignment = HorizontalAlignment.Left,
                //            Height = 20,
                //            Width = 120,
                //            Margin = new Thickness(0, 100, 0, 0)
                //        };

                //        infoGrid.Children.Add(lblStreet);
                //        infoGrid.Children.Add(lblTown);
                //        infoGrid.Children.Add(lblPost);
                //    }




                //}
                



                TextBlock lblRestName = new TextBlock()
                {
                    Text = "EzyPos",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    TextAlignment = TextAlignment.Right,
                    Width = 120,
                    Height = 20,
                    FontSize = 16,
                    Margin = new Thickness(0, 0, 0, 0)
                };
                lblRestName.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                //Grid.SetColumn(lblName, 1);

                TextBlock lblRestPost = new TextBlock()
                {
                    Text = "40100",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    TextAlignment = TextAlignment.Right,
                    Height = 20,
                    Width = 120,
                    Margin = new Thickness(0, 40, 0, 0),
                    FontSize = 14,//14
                    FontWeight = FontWeights.Bold
                };
                //Grid.SetColumn(lblHouseNo, 1);

                TextBlock lblCallNow = new TextBlock()
                {
                    Text = "Call Now",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    TextAlignment = TextAlignment.Right,
                    Height = 20,
                    Width = 120,
                    Margin = new Thickness(0, 70, 0, 0),
                    FontSize = 14,//14
                    FontWeight = FontWeights.Normal
                };
                //Grid.SetColumn(lblStreet, 1);

                TextBlock lblCall = new TextBlock()
                {
                    Text = "03215115527",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    TextAlignment = TextAlignment.Right,
                    Height = 20,
                    Width = 120,
                    Margin = new Thickness(0, 100, 0, 0),
                    FontSize = 14,//14
                    FontWeight = FontWeights.Normal
                };
                //Grid.SetColumn(lblTown, 1);


                infoGrid.Children.Add(lblRestName);
                infoGrid.Children.Add(lblRestPost);
                infoGrid.Children.Add(lblCallNow);
                infoGrid.Children.Add(lblCall);


                p.Inlines.Add(infoGrid);
                flowDocument.Blocks.Add(p);

                //---Order Deteals

                List<OrderDetail> items = order.OrdersDetails.ToList();
                foreach (var item in items)
                {
                    StackPanel orderDetails = new StackPanel();
                    orderDetails.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left;

                    Grid lineDetails = new Grid();
                    lineDetails.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left;
                    lineDetails.Margin = new Thickness(0, 10, 0, 0);

                    WrapPanel span = new WrapPanel();
                    span.Orientation = Orientation.Horizontal;
                    span.HorizontalAlignment = HorizontalAlignment.Left;
                    span.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left - 50;

                    lineDetails.Children.Add(span);
                    TextBlock qty = new TextBlock()
                    {
                        Text = item.Qty.ToString(),
                        FontSize = 14,//14
                        FontWeight = FontWeights.Bold,
                        FontFamily = new FontFamily(Constants.FontFamily)
                    };
                    span.Children.Add(qty);



                    TextBlock name = new TextBlock()
                    {
                        Text = item.Item.name,
                        FontSize = 14,//14
                        FontWeight = FontWeights.Bold,
                        TextWrapping = TextWrapping.Wrap,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        FontFamily = new FontFamily(Constants.FontFamily)
                    };

                    

                    
                    TextBlock total = new TextBlock()
                    {
                        Text = item.GetTotal.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
                        Width = 60,
                        FontSize = 14,//14
                        FontWeight = FontWeights.Bold,
                        TextAlignment = TextAlignment.Right,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontFamily = new FontFamily(Constants.FontFamily)
                    };

                    span.Children.Add(name);
                    lineDetails.Children.Add(total);

                    orderDetails.Children.Add(lineDetails);



                    if (!string.IsNullOrWhiteSpace(item.Note))
                    {
                        TextBlock cmt = new TextBlock()
                        {
                            Text = item.Note,
                            Width = pageWidth - 20,
                            FontStyle = FontStyles.Italic,
                            TextWrapping = TextWrapping.Wrap,
                            Margin = new Thickness(10, 0, 0, 0)
                        };
                        orderDetails.Children.Add(cmt);
                    }

                    p.Inlines.Add(orderDetails);
                   
                  
                    ////---line------------------------------------------
                    
                        TextBlock Line = new TextBlock()
                        {
                            Text = "----------------------------------------------",
                            Width = pageWidth - 20,
                            FontStyle = FontStyles.Italic,
                            TextWrapping = TextWrapping.Wrap,
                            Margin = new Thickness(0, 0, 0, 0),
                            FontWeight = FontWeights.Bold
                        };
                        orderDetails.Children.Add(Line);
                        //orderDetails.Children.Add(Line(pageWidth, new Thickness(0, 0, 0, 0)));
                    





                }

                //if (!string.IsNullOrWhiteSpace(order.description))
                //{
                //    TextBlock cmt = new TextBlock()
                //    {
                //        Text = order.description,
                //        Width = pageWidth - 20,
                //        FontStyle = FontStyles.Italic,
                //        TextWrapping = TextWrapping.Wrap,
                //        Margin = new Thickness(10, 0, 0, 0)
                //    };
                //    p.Inlines.Add(cmt);
                //}

                Grid billSummery = new Grid();
                billSummery.Width = pageWidth - flowDocument.PagePadding.Left - flowDocument.PagePadding.Right;
                TextBlock lblSubTotal = new TextBlock()
                {
                    Text = "Sub Total",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextAlignment = TextAlignment.Left,
                    Width = 120,
                    Height = 20,
                    //Margin = new Thickness(0, 0, 0, 0),
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };

                TextBlock lblDel = new TextBlock()
                {
                    Text = "Delivery Charges",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = 20,
                    Width = 150,
                    // Margin = new Thickness(0, 50, 0, 0),
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };

                TextBlock lblDisc = new TextBlock()
                {
                    Text = "Discount",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = 20,
                    Width = 120,
                    //Margin = new Thickness(0, 100, 0, 0),
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };
                TextBlock lblService = new TextBlock()
                {
                    Text = "Service Charges",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = 20,
                    Width = 150,
                    //Margin = new Thickness(0, 150, 0, 0),
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };

                TextBlock lblTotal = new TextBlock()
                {
                    Text = "Total",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Height = 20,
                    Width = 120,
                    // Margin = new Thickness(0, 200, 0, 0),
                    //FontSize = 17
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };

                //lblTotal.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                int SummaryTopmargin = 0;
                int SummaryBlockmargin = 0;
                if (order.GetTotal() > 0)
                {
                    SummaryBlockmargin += -20;
                    lblSubTotal.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
                    billSummery.Children.Add(lblSubTotal);
                }
                
                if (order.Discount > 0)
                {
                    SummaryBlockmargin += -20;
                    SummaryTopmargin += 50;
                    lblDisc.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
                    billSummery.Children.Add(lblDisc);
                }
               
                SummaryTopmargin += 50;
                lblTotal.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
                billSummery.Children.Add(lblTotal);

                // reinitializing  SummaryTopmargin 

                SummaryTopmargin = 0;

                TextBlock lblSubAmt = new TextBlock()
                {
                    Text = order.GetTotal().ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    TextAlignment = TextAlignment.Right,
                    Width = 120,
                    Height = 20,
                    //Margin = new Thickness(0, 0, 0, 0),
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };
                //Grid.SetColumn(lblName, 1);

                
                //Grid.SetColumn(lblHouseNo, 1);

                TextBlock lblDiscAmt = new TextBlock()
                {
                    Text = order.Discount == null ? "0" : order.Discount.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    TextAlignment = TextAlignment.Right,
                    Height = 20,
                    Width = 120,
                    FontSize =14,//14
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                    //Margin = new Thickness(0, 100, 0, 0)

                };

                

                TextBlock lblTotalAmt = new TextBlock()
                {
                    Text = order.GetNetTotal().ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    TextAlignment = TextAlignment.Right,
                    Height = 20,
                    Width = 120,
                    FontSize = 16,//14
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                    //Margin = new Thickness(0, 200, 0, 0)
                };
                //lblTotalAmt.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                //Grid.SetColumn(lblStreet, 1);

                if (order.GetTotal() > 0)
                {
                    lblSubAmt.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
                    billSummery.Children.Add(lblSubAmt);
                }
                
                if (order.Discount > 0)
                {
                    SummaryTopmargin += 50;
                    lblDiscAmt.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
                    billSummery.Children.Add(lblDiscAmt);
                }
                
                SummaryTopmargin += 50;
                lblTotalAmt.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
                billSummery.Children.Add(lblTotalAmt);

                billSummery.Margin = new Thickness(0, SummaryBlockmargin, 0, 0);
                p.Inlines.Add(billSummery);
                TextBlock Linesecond = new TextBlock()
                {
                    Text = "----------------------------------------------",
                    Width = pageWidth - 20,
                    FontStyle = FontStyles.Italic,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(0, 0, 0, 0),
                    FontWeight = FontWeights.Bold
                };
                p.Inlines.Add(Linesecond);
                //p.Inlines.Add(Line(pageWidth, new Thickness(0)));

                TextBlock lblReceive = new TextBlock()
                {
                    Text = "Received at: " + order.OrderDate.ToString("dd/MM/yyyy hh:mm tt"),
                    Width = pageWidth,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Height = 20,
                    FontSize = 12,//14
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };
                p.Inlines.Add(lblReceive);

                TextBlock Restaurant = new TextBlock()
                {
                    Text = "Ezypos shop",
                    Width = pageWidth,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Height = 20,
                    FontWeight = FontWeights.Bold,
                    FontSize=14,
                    FontFamily = new FontFamily(Constants.FontFamily)


                };
                p.Inlines.Add(Restaurant);

                //TextBlock lblOrderCount = new TextBlock()
                //{
                //    Text = "Order Count: " + order.order_count.ToString(),
                //    Width = pageWidth,
                //    TextAlignment = TextAlignment.Center,
                //    HorizontalAlignment = HorizontalAlignment.Center,
                //    Height = 20,
                //    FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),
                //    FontWeight = FontWeights.Bold
                //};
                //lblOrderCount.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
               // p.Inlines.Add(lblOrderCount);

                //TextBlock lblOrderCountNo = new TextBlock()
                //{
                //    Text = order.order_count.ToString(),
                //    Width = pageWidth,
                //    TextAlignment = TextAlignment.Center,
                //    Height = 20,
                //    HorizontalAlignment = HorizontalAlignment.Center,
                //    FontSize = 13,
                //    FontWeight = FontWeights.Bold
                //};

                //lblOrderCountNo.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                //p.Inlines.Add(lblOrderCountNo);

                

                //TextBlock lblServedname = new TextBlock()
                //{
                //    Text =  order.addby,
                //    Width = pageWidth,
                //    TextAlignment = TextAlignment.Center,
                //    HorizontalAlignment = HorizontalAlignment.Center,
                //    FontWeight=FontWeights.Bold
                //};
                //p.Inlines.Add(lblServedname);

                TextBlock lblTrans = new TextBlock()
                {
                    Text = "Transaction #",
                    Width = pageWidth,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 14,//14
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily(Constants.FontFamily)
                };
                p.Inlines.Add(lblTrans);

                TextBlock lblTranNo = new TextBlock()
                {
                    Text = order.OrderId.ToString(),
                    Width = pageWidth,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontWeight = FontWeights.Bold,
                    FontSize = 14,
                };
                p.Inlines.Add(lblTranNo);

                //TextBlock lblMessage = new TextBlock()
                //{
                //    Text = ActiveSession.Client_Preferences.receipt_message,
                //    // FontSize = 12,
                //    FontStyle = FontStyles.Italic,
                //    TextAlignment = TextAlignment.Center,
                //    Margin = new Thickness(0, 22, 0, 0),
                //    Width = pageWidth - flowDocument.PagePadding.Left - flowDocument.PagePadding.Right,
                //    TextWrapping = TextWrapping.Wrap,
                //    FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
                //    FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal
                //};
                //p.Inlines.Add(lblMessage);





                
            }
            catch (Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "Ok");
            }
            return flowDocument;
        }

        //public static FlowDocument GetFlowDocumentFromCartAsync(Order order)
        //{

        //    FlowDocument flowDocument = null;
        //    try
        //    {
        //        string imgPath = Environment.CurrentDirectory;
        //        jayeatEntities entities = new jayeatEntities();


        //        double pageWidth = 288;
        //        flowDocument = new FlowDocument();
        //        flowDocument.PageWidth = pageWidth;
        //        flowDocument.PagePadding = new Thickness(10);
        //        flowDocument.FontFamily = new FontFamily(Constants.FontFamily);
        //        flowDocument.FontSize = 12;

        //        Paragraph p = new Paragraph();


        //        TextBlock lblOrderType = new TextBlock()
        //        {
        //            Text = "Order Summary",
        //            Width = pageWidth,
        //            TextAlignment = TextAlignment.Center,
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //            Height = 40,
        //            FontSize = 20,
        //        };
        //        lblOrderType.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);

        //        p.Inlines.Add(lblOrderType);

        //        flowDocument.Blocks.Add(p);

        //        //---Order Deteals

        //        var items = order.OrdersDetails.OrderBy(x => x.Item.sort_order).ToList();
        //        foreach (var item in items)
        //        {
        //            sub_categories subCategory = entities.sub_categories.SingleOrDefault(x => x.id == item.Item.sub_cat_id);
        //            StackPanel orderDetails = new StackPanel();
        //            orderDetails.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left;

        //            Grid lineDetails = new Grid();
        //            lineDetails.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left;
        //            lineDetails.Margin = new Thickness(0, 10, 0, 0);

        //            WrapPanel span = new WrapPanel();
        //            span.Orientation = Orientation.Horizontal;
        //            span.HorizontalAlignment = HorizontalAlignment.Left;
        //            span.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left - 50;

        //            lineDetails.Children.Add(span);
        //            TextBlock qty = new TextBlock()
        //            {
        //                Text = item.Qty.ToString(),
        //                FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal, //FontWeights.Bold
        //                Padding = new Thickness(0, 0, 5, 0),
        //                FontFamily = new FontFamily(Constants.FontFamily)
        //            };
        //            span.Children.Add(qty);



        //            TextBlock name = new TextBlock()
        //            {
        //                Text = item.Item.name,
        //                FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
        //                TextWrapping = TextWrapping.Wrap,
        //                VerticalAlignment = VerticalAlignment.Bottom,
        //                FontFamily = new FontFamily(Constants.FontFamily)
        //            };

        //            if (ActiveSession.Client_Preferences.order_catname_print.ToLower() == "active" && ActiveSession.Client_Preferences.inline_cat_name.ToLower() == "active")
        //            {
        //                name.Text = subCategory.name + " : " + item.Item.name;
        //                name.Padding = new Thickness(0, 0, 5, 0);
        //                //name.FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                //name.FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,

        //            }

        //            if (ActiveSession.Client_Preferences.order_catname_print.ToLower() == "active" && ActiveSession.Client_Preferences.inline_cat_name.ToLower() == "inactive")
        //            {
        //                TextBlock subCat = new TextBlock()
        //                {
        //                    Text = subCategory?.name + ":",
        //                    FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                    FontWeight = FontWeights.Bold,
        //                    Padding = new Thickness(0, 0, 5, 0),
        //                    FontFamily = new FontFamily(Constants.FontFamily)
        //                };
        //                span.Children.Add(subCat);
        //            }

        //            TextBlock total = new TextBlock()
        //            {
        //                Text = item.GetTotal.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
        //                Width = 60,
        //                FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
        //                TextAlignment = TextAlignment.Right,
        //                HorizontalAlignment = HorizontalAlignment.Right,
        //                VerticalAlignment = VerticalAlignment.Top,
        //                FontFamily = new FontFamily(Constants.FontFamily)
        //            };

        //            span.Children.Add(name);
        //            lineDetails.Children.Add(total);
        //            orderDetails.Children.Add(lineDetails);




        //            p.Inlines.Add(orderDetails);

        //            var adon = item.AdonItems?.OrderBy(x => x.sort_order).ToList();
        //            if (adon != null)
        //            {
        //                foreach (var a in adon)
        //                {

        //                    if (a != null)
        //                    {

        //                        Grid addonLineDetails = new Grid();
        //                        addonLineDetails.Width = lineDetails.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left;

        //                        WrapPanel spanAddon = new WrapPanel();
        //                        spanAddon.Orientation = Orientation.Horizontal;
        //                        spanAddon.HorizontalAlignment = HorizontalAlignment.Left;
        //                        spanAddon.Width = pageWidth - flowDocument.PagePadding.Right - flowDocument.PagePadding.Left - 50;
        //                        addonLineDetails.Children.Add(spanAddon);

        //                        TextBlock addonQty = new TextBlock()
        //                        {
        //                            Text = "-> " + a.qty.ToString(),
        //                            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
        //                        };

        //                        TextBlock addonName = new TextBlock()
        //                        {
        //                            Text = " " + a.name.Replace('?', '➤'),
        //                            TextWrapping = TextWrapping.Wrap,
        //                            VerticalAlignment = VerticalAlignment.Bottom,
        //                            FontFamily = new FontFamily(Constants.FontFamily),
        //                            //Width = 197,
        //                            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
        //                        };

        //                        //if (addon_Item.addon_print_bold.ToLower() == "yes")
        //                        //    addonName.FontWeight = FontWeights.Bold;

        //                        TextBlock addonTotal = new TextBlock()
        //                        {
        //                            Text = item.GetAddonTotal().ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
        //                            Width = 60,
        //                            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //                            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
        //                            HorizontalAlignment = HorizontalAlignment.Right,
        //                            TextAlignment = TextAlignment.Right
        //                        };

        //                        spanAddon.Children.Add(addonQty);
        //                        spanAddon.Children.Add(addonName);
        //                        addonLineDetails.Children.Add(addonTotal);
        //                        orderDetails.Children.Add(addonLineDetails);


        //                    }


        //                }
        //            }
        //            ////---line------------------------------------------
        //            if (ActiveSession.Client_Preferences.print_item_lines.ToLower() == "yes")
        //            {
        //                TextBlock Line = new TextBlock()
        //                {
        //                    Text = "----------------------------------------------",
        //                    Width = pageWidth - 20,
        //                    FontStyle = FontStyles.Italic,
        //                    TextWrapping = TextWrapping.Wrap,
        //                    Margin = new Thickness(0, 0, 0, 0),
        //                    FontWeight = FontWeights.Bold
        //                };
        //                orderDetails.Children.Add(Line);
        //                //orderDetails.Children.Add(Line(pageWidth, new Thickness(0, 0, 0, 0)));
        //            }

        //        }

        //        Grid billSummery = new Grid();
        //        billSummery.Width = pageWidth - flowDocument.PagePadding.Left - flowDocument.PagePadding.Right;
        //        TextBlock lblSubTotal = new TextBlock()
        //        {
        //            Text = "Sub Total",
        //            HorizontalAlignment = HorizontalAlignment.Left,
        //            TextAlignment = TextAlignment.Left,
        //            Width = 120,
        //            Height = 20,
        //            //Margin = new Thickness(0, 0, 0, 0),
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal
        //        };

        //        TextBlock lblDel = new TextBlock()
        //        {
        //            Text = "Delivery Charges",
        //            HorizontalAlignment = HorizontalAlignment.Left,
        //            Height = 20,
        //            Width = 150,
        //            // Margin = new Thickness(0, 50, 0, 0),
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal
        //        };

        //        TextBlock lblDisc = new TextBlock()
        //        {
        //            Text = "Discount",
        //            HorizontalAlignment = HorizontalAlignment.Left,
        //            Height = 20,
        //            Width = 120,
        //            //Margin = new Thickness(0, 100, 0, 0),
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal
        //        };
        //        TextBlock lblService = new TextBlock()
        //        {
        //            Text = "Service Charges",
        //            HorizontalAlignment = HorizontalAlignment.Left,
        //            Height = 20,
        //            Width = 150,
        //            //Margin = new Thickness(0, 150, 0, 0),
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal
        //        };

        //        TextBlock lblTotal = new TextBlock()
        //        {
        //            Text = "Total",
        //            HorizontalAlignment = HorizontalAlignment.Left,
        //            Height = 20,
        //            Width = 120,
        //            // Margin = new Thickness(0, 200, 0, 0),
        //            //FontSize = 17
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()) + 2,//14
        //            FontWeight = FontWeights.Bold
        //        };

        //        //lblTotal.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
        //        int SummaryTopmargin = 0;
        //        int SummaryBlockmargin = 0;
        //        if (order.GetTotal() > 0)
        //        {
        //            SummaryBlockmargin += -20;
        //            lblSubTotal.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblSubTotal);
        //        }
        //        if (order.DeliverCharges > 0)
        //        {
        //            SummaryBlockmargin += -20;
        //            SummaryTopmargin += 50;
        //            lblDel.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblDel);
        //        }
        //        if (order.Discount > 0)
        //        {
        //            SummaryBlockmargin += -20;
        //            SummaryTopmargin += 50;
        //            lblDisc.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblDisc);
        //        }
        //        if (order.ServiceCharges > 0)
        //        {
        //            SummaryBlockmargin += -20;
        //            SummaryTopmargin += 50;
        //            lblService.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblService);
        //        }
        //        SummaryTopmargin += 50;
        //        lblTotal.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //        billSummery.Children.Add(lblTotal);

        //        // reinitializing  SummaryTopmargin 

        //        SummaryTopmargin = 0;

        //        TextBlock lblSubAmt = new TextBlock()
        //        {
        //            Text = order.GetTotal().ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
        //            HorizontalAlignment = HorizontalAlignment.Right,
        //            TextAlignment = TextAlignment.Right,
        //            Width = 120,
        //            Height = 20,
        //            //Margin = new Thickness(0, 0, 0, 0),
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal
        //        };
        //        //Grid.SetColumn(lblName, 1);

        //        TextBlock lblDelAmt = new TextBlock()
        //        {
        //            Text = order.DeliverCharges.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
        //            HorizontalAlignment = HorizontalAlignment.Right,
        //            TextAlignment = TextAlignment.Right,
        //            Height = 20,
        //            Width = 120,
        //            // Margin = new Thickness(0, 50, 0, 0),
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal
        //        };
        //        //Grid.SetColumn(lblHouseNo, 1);

        //        TextBlock lblDiscAmt = new TextBlock()
        //        {
        //            Text = order.Discount == null ? "0" : order.Discount.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
        //            HorizontalAlignment = HorizontalAlignment.Right,
        //            TextAlignment = TextAlignment.Right,
        //            Height = 20,
        //            Width = 120,
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
        //            //Margin = new Thickness(0, 100, 0, 0)

        //        };

        //        TextBlock lblservice = new TextBlock()
        //        {
        //            Text = order.ServiceCharges == null ? "0" : order.ServiceCharges.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
        //            HorizontalAlignment = HorizontalAlignment.Right,
        //            TextAlignment = TextAlignment.Right,
        //            Height = 20,
        //            Width = 120,
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()),//14
        //            FontWeight = ActiveSession.Client_Preferences.print_bold.ToLower().ToString() == "yes" ? FontWeights.Bold : FontWeights.Normal,
        //            //Margin = new Thickness(0, 150, 0, 0)

        //        };

        //        TextBlock lblTotalAmt = new TextBlock()
        //        {
        //            Text = order.GetNetTotal().ToString("C", CultureInfo.CreateSpecificCulture("en-GB")),
        //            HorizontalAlignment = HorizontalAlignment.Right,
        //            TextAlignment = TextAlignment.Right,
        //            Height = 20,
        //            Width = 120,
        //            FontSize = Convert.ToDouble(ActiveSession.Client_Preferences.print_font.ToString()) + 2,//14
        //            FontWeight = FontWeights.Bold,
        //            //Margin = new Thickness(0, 200, 0, 0)
        //        };
        //        //lblTotalAmt.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
        //        //Grid.SetColumn(lblStreet, 1);

        //        if (order.GetTotal() > 0)
        //        {
        //            lblSubAmt.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblSubAmt);
        //        }

        //        if (order.DeliverCharges > 0)
        //        {
        //            SummaryTopmargin += 50;
        //            lblDelAmt.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblDelAmt);
        //        }
        //        if (order.Discount > 0)
        //        {
        //            SummaryTopmargin += 50;
        //            lblDiscAmt.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblDiscAmt);
        //        }
        //        if (order.ServiceCharges > 0)
        //        {
        //            SummaryTopmargin += 50;
        //            lblservice.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //            billSummery.Children.Add(lblservice);
        //        }
        //        SummaryTopmargin += 50;
        //        lblTotalAmt.Margin = new Thickness(0, SummaryTopmargin, 0, 0);
        //        billSummery.Children.Add(lblTotalAmt);

        //        billSummery.Margin = new Thickness(0, SummaryBlockmargin, 0, 0);
        //        p.Inlines.Add(billSummery);
        //        TextBlock Linesecond = new TextBlock()
        //        {
        //            Text = "----------------------------------------------",
        //            Width = pageWidth - 20,
        //            FontStyle = FontStyles.Italic,
        //            TextWrapping = TextWrapping.Wrap,
        //            Margin = new Thickness(0, 0, 0, 0),
        //            FontWeight = FontWeights.Bold
        //        };
        //        p.Inlines.Add(Linesecond);




        //        if (entities != null)
        //            entities.Dispose();
        //    }
        //    catch (Exception exp)
        //    {
        //        Epos.Views.MessageBox.ShowCustom(exp.Message, "Error", "Ok");
        //    }
        //    return flowDocument;
        //}
        //public static List<FlowDocument> GetFlowDocumentsCart(Order order)
        //{

        //    List<FlowDocument> flowDocuments = new List<FlowDocument>();
        //    try
        //    {

        //        flowDocuments.Add(GetFlowDocumentFromCartAsync(order));
        //    }
        //    catch (Exception ex)
        //    {
        //        View.MessageBox.ShowCustom(ex.Message, "Error", "Ok");
        //    }

        //    return flowDocuments;
        //}


       
        public void Print(Order odr)
        {
            try
            {
                bool isPrint = false;
                int printcount = 1;              

                if (printcount != 0)
                {                    
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            isPrint = EZYPOS.View.MessageYesNo.ShowCustom("Print Invoice", "Do you want to print invoice.", "Yes", "No");
                        });                   
                    
                }

                PrintDialog print = new PrintDialog();

                if (isPrint)
                {
                    order = odr;
                    //order.BillSplit = new ObservableCollection<order_detail>(context.order_detail.Where(x => x.order_id == odr.id).ToList());
                    //order.Customer = context.customers.FirstOrDefault(x => x.id == odr.user_id);

                    foreach (FlowDocument document in GetFlowDocuments(order))
                    {
                        for (int i = 1; i <= printcount; i++)
                        {

                            print.PrintDocument(((IDocumentPaginatorSource)document).DocumentPaginator, "Order No." + order.OrderId.ToString());

                        }
                    }                    

                }
               
            }
            catch (Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "Ok");
            }
        }

        public static Line Line(double pageWidth, Thickness margin)
        {
            Line line = new Line()
            {
                X1 = 0,
                X2 = pageWidth,
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                StrokeDashArray = new DoubleCollection(2),
                StrokeDashOffset = 2,
                Margin = margin,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            return line;
        }

        private FlowDocument printLable(OrderDetail order_Detail)
        {
            FlowDocument f = new FlowDocument();
            try
            {
                f.PageWidth = Constants.LabelPrintWidth; //288 //350 //336
                f.PageHeight = Constants.LabelPrintHeight; //96; //auto
                f.Blocks.Add(new Paragraph(new Run(order_Detail.Item.name))/* { TextAlignment = TextAlignment.Center }*/);
                f.Blocks.Add(new Paragraph(new Run(order_Detail.Qty.ToString())) { /*TextAlignment = TextAlignment.Center,*/ Margin = new Thickness(0, 10, 0, 0), FontSize = 14, FontWeight = FontWeights.Bold });
                f.FontFamily = new FontFamily(Constants.FontFamily);
                f.FontWeight = FontWeights.Normal;
                f.FontSize = 12;
                f.TextAlignment = TextAlignment.Center;
                Style style = new Style(typeof(Paragraph));
                //style.Setters.Add(new Setter(Block.TextAlignmentProperty, TextAlignment.Center));
                f.Resources.Add(typeof(Paragraph), style);
            }
            catch (Exception exp)
            {
                EZYPOS.View.MessageBox.ShowCustom(exp.Message, "Error", "Ok");
            }
            return f;
        }

        public void DoPrintJob(Order order)
        {
            Thread thread = new Thread(() => Print(order));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        //public void DoPrintJobFromOrderView(order order)
        //{
        //    Thread thread = new Thread(() => PrintForOrderView(order));
        //    thread.SetApartmentState(ApartmentState.STA);
        //    thread.IsBackground = true;
        //    thread.Start();
        //}

        //public static List<order_detail> GetSplitOrderDetails(int? billNo, int orderId)
        //{
        //    List<order_detail> order_Details = null;
        //    try
        //    {
        //        jayeatEntities entities = new jayeatEntities();
        //        order_Details = entities.order_detail.Where(x => x.order_id == orderId && x.bill_no == billNo).ToList();

        //        if (entities != null)
        //            entities.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        Views.MessageBox.ShowCustom(ex.Message, "Error", "Ok");
        //    }
        //    return order_Details;
        //}

        public static List<FlowDocument> GetFlowDocuments(Order order)
        {

            List<FlowDocument> flowDocuments = new List<FlowDocument>();
            try
            {   
                flowDocuments.Add(GetFlowDocumentAsync(order));
            }
            catch (Exception ex)
            {
                View.MessageBox.ShowCustom(ex.Message, "Error", "Ok");
            }

            return flowDocuments;
        }
    }
}
