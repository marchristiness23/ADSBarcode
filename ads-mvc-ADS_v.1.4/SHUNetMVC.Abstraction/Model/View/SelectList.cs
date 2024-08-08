using System.Collections.Generic;

namespace SHUNetMVC.Abstraction.Model.View
{
    public class LookupList
    {
        
        public string ColumnId { get; set; }
        public List<LookupItem> Items { get; set; }
    }

    public class LookupItem
    {
        public string Text { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Untuk selection yang lebih dari 1 property untuk di view
        /// </summary>
        public object Object { get; set; }

        public string Value { get; set; }
        public bool Selected { get; set; }
    }
}
