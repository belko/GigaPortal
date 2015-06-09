using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaPortalData.Modules
{
    public enum ModuleType 
    {
        News=1
    }
    public class Module
    {
        ModuleType Type;
        string Settings;
        string ViewName;
        public Module()
        {
        }
        public Module(string settings)
        {
            this.Settings = settings;
        }

    }
    
}
