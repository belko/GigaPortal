using GigaPortalData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GigaPortal.Models
{
    public class ListGPObjectsModel
    {
        public string Title { get; set; }
        public List<IGPObject> Items { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary route { get; set; }
    }
}