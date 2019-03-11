using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuturionNewsfeed.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreationDateTime { get; set; }
        public string CreatorUsername { get; set; }
        public IList<Comment> Comments { get; set; }
        public int NumberOfComments => Comments.Count;
    }
}
