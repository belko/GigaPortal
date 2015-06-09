using GigaPortalData.Interfaces;
using GigaPortalData.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaPortalData.Models
{
    public class GPWeb:IGPObject
    {
        public GPWeb() 
        {
           
        }
        
        public  Nullable<int> ParentWebId { get; set; }
        public virtual GPWeb ParentWeb { get; set; }
        public string Url { get; set; }

        #region IGCObjects

        public int Id { get; set; }
        
        [NotMapped]
        public int CurrentWebId
        {
            get;
            set;
        }
        
        public string Title { get; set; }
        public string Description { get; set; }

        public Nullable<DateTime> CreateDate
        {
            get;
            set;
        }

        public string Creator
        {
            get;
            set;
        }

        #endregion


    }
}
