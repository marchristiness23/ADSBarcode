using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Model.Entities
{
    public partial class DB_PHE_ADSEntities
    {
        public DB_PHE_ADSEntities(string connectionString)
           : base(connectionString)
        {
        }
    }
}
