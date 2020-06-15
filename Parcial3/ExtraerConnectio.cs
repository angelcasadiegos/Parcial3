using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Parcial3
{
    class ExtraerConnectio
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DESKTOP-2HFRPRB"].ConnectionString;
    }
}
