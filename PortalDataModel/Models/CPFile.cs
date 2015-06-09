using System;
using System.Collections.Generic;

namespace GigaPortalData.Models
{
    public class CPFile
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public byte[] FileContentB { get; set; }
        public int DocLibId { get; set; }
        public byte[] FileContent { get; set; }
        public System.Guid FileGUID { get; set; }
        public virtual DocumentLibrary DocLib { get; set; }
    }
}
