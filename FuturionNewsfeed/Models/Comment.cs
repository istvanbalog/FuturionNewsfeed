using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuturionNewsfeed.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Megjegyzés szövege")]
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreationDateTime { get; set; }
        public string CreatorUsername { get; set; }
        public NewsItem News { get; set; }
    }
}
