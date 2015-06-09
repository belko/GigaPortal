using GigaPortalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigaPortal
{
    public static class GPExtentions
    {



        private const string cCurrentWebName = "depname";
        private const string cCurrentWeb = "currentWeb";
        public static string webRoleFormat = "{0}_{1}";
        public static string NameForRole(this System.Security.Principal.IIdentity identity)
        {

            return identity.Name.Replace("\\", "_");
        }
        public static string GetUserNameFromUserInRoleName(this string nameInRole)
        {
            return nameInRole.Replace("_", "\\");
        }
        public static GPWeb CurrentWeb(this Controller controller)
        {

            if (controller.HttpContext.Items[cCurrentWeb] != null)
                return (GPWeb)controller.HttpContext.Items[cCurrentWeb];
            else
            {
                GPWeb web;
                using (PortalDataContext context = new PortalDataContext())
                {

                    if (controller.RouteData.Values.ContainsKey(cCurrentWebName))
                    {
                        string webUrl = controller.RouteData.Values[cCurrentWebName].ToString();
                        web = context.Webs.Where(w => w.Url == webUrl).FirstOrDefault();
                        
                    }
                    else
                    {
                        web = context.Webs.Where(w=> w.ParentWebId==null ).FirstOrDefault();
                    }

                }
                controller.HttpContext.Items[cCurrentWeb] = web;
                return web;
            }
        }


    }


}
