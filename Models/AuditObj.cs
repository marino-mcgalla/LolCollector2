using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinApp.Models
{
    abstract public class AuditObj
    {
        public int Votes { get; set; }
        public int Views { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
