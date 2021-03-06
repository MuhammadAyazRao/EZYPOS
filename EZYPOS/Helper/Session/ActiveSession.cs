﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.Helper.Session
{
  public static  class ActiveSession
    {
        public static bool PrintLogo = true;
        public static double order_Discount_percentage;
        public delegate void CommunucationHandler(object parameter);
        
        public static event CommunucationHandler NavigateToHomeView;
        public static void NavigateToHome(object parameter)
        {
            NavigateToHomeView?.Invoke(parameter);
        }


        public static event CommunucationHandler SwitchScreen;
        public static void NavigateToSwitchScreen(object parameter)
        {
            SwitchScreen?.Invoke(parameter);
        }

        public static event CommunucationHandler RefreshCustomerList;
        public static void NavigateToRefreshCustomerList(object parameter)
        {
            RefreshCustomerList?.Invoke(parameter);
        }

        public static event CommunucationHandler RefreshSupplierList;
        public static void NavigateToRefreshSupplierList(object parameter)
        {
            RefreshSupplierList?.Invoke(parameter);
        }


        public static event CommunucationHandler RefreshExpenceHead;
        public static void NavigateToRefreshExpenceHeadList(object parameter)
        {
            RefreshExpenceHead?.Invoke(parameter);
        }

        public static event CommunucationHandler RefreshEmployeeList;
        public static void NavigateToRefreshEmployeeList(object parameter)
        {
            RefreshEmployeeList?.Invoke(parameter);
        }

        public static event CommunucationHandler ShowMenu;
        public static void NavigateToShowMenu(object parameter)
        {
            ShowMenu?.Invoke(parameter);
        }

        public static event CommunucationHandler RefreshMenu;
        public static void NavigateToRefreshMenu(object parameter)
        {
            RefreshMenu?.Invoke(parameter);
        }
        public static event CommunucationHandler HideMenu;
        public static void NavigateToHideMenu(object parameter)
        {
            HideMenu?.Invoke(parameter);
        }

        public static void Logout()
        {
            RefreshCustomerList = null;
        }
    }
}
