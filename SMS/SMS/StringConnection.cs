using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    public class StringConnection
    {
        public static string ConnectionString()
        {
            //return @"Data Source=Abanoub\SQLEXPRESS;Initial Catalog=Teacher;Integrated Security=True;";
            return @"Data Source=ERROR-404\SQLEXPRESS;Initial Catalog=Teacher;Integrated Security=True;";
            //ramez
           // return @"Data Source=DESKTOP-O7HKUI0\SQLEXPRESS;Initial Catalog=Teacher;Integrated Security=True;";
        }
    }
}
