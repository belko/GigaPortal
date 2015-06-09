using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaPortalData.Interfaces
{
    public interface IGPObject
    {
        int CurrentWebId { get; set; }
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        Nullable<DateTime> CreateDate { get; set; }
        string Creator { get; set; }
        
    }

    public interface IGPItemsCollection:IGPObject 
    {
        string CollectionType { get; }
        List<IGPItem> Items { get; set; }
    }

    public interface IGPItem : IGPObject 
    {
        int CollectionId { get; set; }
        int LocalId { get; set; }
    }
}
