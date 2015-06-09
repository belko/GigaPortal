using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigaPortalData.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
namespace GigaPortalData.Models.Collections
{
    public class GPNewsCollection:IGPItemsCollection
    {

         

        #region IGPItemsCollection

        [NotMapped]
        public List<IGPItem> Items { get; set; }

        public int Id { get; set; }

        public string CollectionType
        {
            get { return "Pages"; }
        }

        public int CurrentWebId { get; set; }
        [ForeignKey("CurrentWebId")]
        public virtual GPWeb CurrentWeb { get; set; }

        
        public string Title { get; set; }

        public string Description { get; set; }

        public Nullable<DateTime> CreateDate { get; set; }

        public string Creator { get; set; }

        #endregion


        
    }
    public class GPNews:IGPItem 
    {
        public int NewsesCollectionId { get; set; }
        [ForeignKey("NewsesCollectionId")]
        public virtual GPNewsCollection NewsesCollection { get; set; }

        [NotMapped]
        public int CurrentWebId { get; set; }
        
        [NotMapped]
        public virtual GPWeb CurrentWeb { get; set; }


        public int LocalId { get; set; }

        public int Id { get; set; }

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

        [NotMapped]
        public int CollectionId
        {
            get
            {
                return this.NewsesCollectionId;
            }
            set
            {
                NewsesCollectionId = value;
            }
        }
    }
}
