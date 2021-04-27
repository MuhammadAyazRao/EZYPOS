using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.View
{
    public static class BusyIndicator
    {
        private static Loader LoadingScreen = null;

        public static void  ShowBusy()
        {
            LoadingScreen = new Loader();
            LoadingScreen.Show();        }

        public static void  CloseBusy()
        {
            LoadingScreen.Close();
        }
    }
}
