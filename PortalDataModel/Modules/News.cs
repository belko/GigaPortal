using GigaPortalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaPortalData.Modules
{
    public class News: Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string ShortContext { 
            get {
                int maxLength = 100;
                int lastIndex = this.Context.Length < 100 ? this.Context.Length : 100;
                return this.Context.Substring(0, lastIndex); }
        }
        [DataType(DataType.MultilineText)]
        public string Context { get; set; }
        public DateTime? PostDate { get; set; }
        public int WebId { get; set; }
        public virtual GPWeb Web { get; set; }
    }
}
