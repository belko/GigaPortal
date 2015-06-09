using System;
using System.Collections.Generic;

namespace GigaPortalData.Models
{
    public class DocumentLibrary
    {
        public DocumentLibrary()
        {
            this.CPFiles = new List<CPFile>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int WebId { get; set; }
        public virtual ICollection<CPFile> CPFiles { get; set; }
        public virtual GPWeb Web { get; set; }
    }
}
