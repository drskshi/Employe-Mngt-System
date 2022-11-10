using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Database
{
    public class ConnectionClass
    {
        public static String connectionString
        {
            get { return @"Data Source=DESKTOP-BN3KOBG\SQLEXPRESS;Initial Catalog=assignmentdb;Integrated Security=True"; }
        }
    }
}
