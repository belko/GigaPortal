using GigaPortalData.Interfaces;
using GigaPortalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaPortalData.Models.Collections
{
    public class GPPagesCollection:IGPItemsCollection 
    {

        public virtual List<GPPage> Pages { get; set; }


        #region IGPItemsCollection
        [NotMapped]
        public List<IGPItem> Items { get; set; }
        
        public int Id { get; set; }

        public string CollectionType
        {
            get { return "Pages"; }
        }

        public int CurrentWebId{get;set;}
        [ForeignKey("CurrentWebId")]
        public virtual GPWeb CurrentWeb { get; set; }
        

        public string Title{get;set;}

        public string Description{get;set;}

        public Nullable<DateTime> CreateDate{get;set;}

        public string Creator{get;set;}

        

        #endregion

       
    }
    public class GPPage:IGPItem
    {
        

        public int PagesCollectionId { get; set; }
        [ForeignKey("PagesCollectionId")]
        public virtual GPPagesCollection PagesCollection { get; set; }
        [NotMapped]
        public int CurrentWebId { get; set; }
        [NotMapped]
        public virtual GPWeb CurrentWeb { get; set; }

        
        public int LocalId{get;set;}

        
        
        public int Id{get;set;}

        public string Title{get;set;}

        public string Description{get;set;}

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

        [NotMapped]
        public int CollectionId
        {
            get
            {
                return this.PagesCollectionId;
            }
            set
            {
                PagesCollectionId = value;
            }
        }

        
    }
}
