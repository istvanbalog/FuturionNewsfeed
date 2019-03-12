using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuturionNewsfeed.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Cím")]
        public string Title { get; set; }
        [DisplayName("Tartalom")]
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Létrehozás dátuma")]
        public DateTime CreationDateTime { get; set; }
        [DisplayName("Létrehozó felhasználóneve")]
        public string CreatorUsername { get; set; }
        [DisplayName("Megjegyzések")]
        public ICollection<Comment> Comments { get; set; }
        public int NumberOfComments => (Comments != null) ? Comments.Count : 0;
        public string ShortenedText => (Text.Length <= 80) ? Text : Text.Substring(0, 80);
    }
}
