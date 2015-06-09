using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaPortalData.Models
{
    public class PortalDataInitializer : DropCreateDatabaseIfModelChanges<PortalDataContext>
    {
        protected override void Seed(PortalDataContext context)
        {




            var webs = new List<GPWeb>
            {
                new GPWeb{Id = 1,Url="root", Title="Root", Description="root"},
                new GPWeb{Id = 2,ParentWebId=1,Url = "sub",Title ="sub"},
                 new GPWeb{Id = 2,ParentWebId=1,Url = "sub2",Title ="sub2"}
            };
            webs.ForEach(w => context.Webs.Add(w));
            context.SaveChanges();
        }
    }
}
