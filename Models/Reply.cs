using SkinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolApp.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public ApplicationUser Author { get; set; }
        public string Message { get; set; }
        public DateTime TimeCreated { get; set; }
        public int Votes { get; set; }
    }
}
