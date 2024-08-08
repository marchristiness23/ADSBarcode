using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Model.Response
{

    public class Object
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class DoTransactionResponse
    {
        public bool Status { get; set; }
        public Object Object { get; set; }
        public string Message { get; set; }
    }

    
}
