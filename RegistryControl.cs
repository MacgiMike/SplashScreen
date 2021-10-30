using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SplashScreen
{
    class RegistryControl
    {
        private string _RegKey = @"HKEY_CURRENT_USER\SOFTWARE\Obsecure\SplashScreen";
        public void SetFirstInstance()
        {
            Registry.SetValue(_RegKey, "AmITheFirst", "no");
        }
        public void RemoveFirstInstance()
        {
            Registry.SetValue(_RegKey, "AmITheFirst", "yes");
        }
        public bool AmITheFirstInstance()
        {
            bool ValueToReturn = false;
            string AmITheFirst = (string)Registry.GetValue(_RegKey, "AmITheFirst", "yes");
            if(AmITheFirst != "no")
            {
                ValueToReturn = true;
            }
            return ValueToReturn;
        }
    }
}
