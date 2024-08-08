using System.Collections.Generic;

namespace SHUNetMVC.Abstraction.Model.View
{
    public class GridParam
    {
        public string GridId { get; set; }

        public string GridJsVar => $"adsGrid['{GridId}']";

        public List<ColumnDefinition> ColumnDefinitions { get; set; }
        public FilterList FilterList { get; set; }

    }
}
