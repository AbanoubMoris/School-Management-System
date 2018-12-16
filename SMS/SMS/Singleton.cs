using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS
{
    public class Singleton
    {
        // Modified from: http://csharpindepth.com/articles/general/singleton.aspx

        // This will keep ONE instance of the Admin Form
        private Admin _adminForm;
        public Admin AdminForm
        {
            get
            {
                if (_adminForm == null)
                {
                    _adminForm = new Admin();
                }
                return _adminForm;
            }
        }
        private static Singleton instance = null;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}

