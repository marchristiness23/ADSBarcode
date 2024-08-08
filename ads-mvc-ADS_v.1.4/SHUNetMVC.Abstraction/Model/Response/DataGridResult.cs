using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Model.Response
{
    public class DataGridResult<TEntity>
    {
        public IEnumerable<TEntity> Data { get; set; }
        public int Total { get; set; }
    }

}
