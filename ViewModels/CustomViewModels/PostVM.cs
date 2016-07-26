using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinApp.ViewModels.CustomViewModels
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public string AuthorName { get; set; }
        public int Votes { get; set; }
        public int Views { get; set; }
        public DateTime TimeCreated { get; set; }
        public int CommentCount { get; set; }

    }
}
