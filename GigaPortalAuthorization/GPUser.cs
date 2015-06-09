using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Principal;
using System.Web.Security;
namespace GigaPortalAuthorization
{
    public enum GPRoleTypes 
    {
        Reader = 1,
        Writer = 2,
        Creator = 4,
        Admin = 8
    }

    public class GPUser
    {
        const string cCGPUserContextName = "GPUserContextConstant";
        private static GPUser _gpuser;
        private SecurityIdentifier _sid;
        public SecurityIdentifier SID { get { return _sid; } }
        private string _userName;
        public string UserName { get{ return _userName; } }
        public static GPUser Instance { 
            get{
                
                if (HttpContext.Current.Session[cCGPUserContextName]==null) 
                {
                    _gpuser = new GPUser();
                    HttpContext.Current.Session.Add(cCGPUserContextName, _gpuser);
                    
                }
                else{
                    _gpuser = HttpContext.Current.Session[cCGPUserContextName] as GPUser;
                    if(_gpuser==null)
                        _gpuser = new GPUser();
                    }
                return _gpuser;
            } 
        }

        public GPUser() 
        {
            _sid = null;
            _userName = HttpContext.Current.User.Identity.Name;
            _userName = _userName.Substring(_userName.IndexOf("\\")+1);
            if (HttpContext.Current.User.Identity.IsAuthenticated) 
            {
                 MembershipUser user = Membership.GetUser(_userName);
                 if (user == null) 
                 {
                     user = Membership.CreateUser(_userName, _userName);
                 }

            }
        }
        
    }

    public class GPRoles 
    {
        
    }
}
