using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling_Station_Management_System
{
    internal class AppSettings
    {
        public static int PumpSelect;
        public static string ConString()
        {
            string connectString = $"server=localhost;Database=filling_station_management_system{PumpSelect + 1};Uid=root;Pwd=''";

            return connectString;
        }

        public static string UserConString()
        {
            return "server=localhost;Database=filling_station_management_system1;Uid=root;Pwd=''";
        }
    }
}
