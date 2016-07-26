using SkinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LolApp.Models
{
    public class ForumPost : AuditObj
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        [Required(ErrorMessage ="You need to say something, silly!")]
        public string Body { get; set; }
        [Required(ErrorMessage ="Category is required.")]
        public string Category { get; set; }
        public ICollection<Reply> Replies { get; set; }
        [Required(ErrorMessage ="Topic is required!")]
        public string Topic { get; set; }
        public ApplicationUser Author { get; set; }
 

    }
}
