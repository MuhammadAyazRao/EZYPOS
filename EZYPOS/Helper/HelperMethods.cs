using Common;
using Common.Session;
using DAL.DBMODEL;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZYPOS.Helper
{
    public class HelperMethods
    {
        public static string GetCurrency()
        {
            return ((List<Setting>)ActiveSession.Setting).Where(x => x.AppKey == SettingKey.Currency).FirstOrDefault().AppValue; 
        }
    }
}
