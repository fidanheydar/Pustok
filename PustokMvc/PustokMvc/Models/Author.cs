using System.ComponentModel.DataAnnotations;

namespace PustokMvc.Models
{
    public class Author:BaseEntity
    {
        [MaxLength(30)]
        [MinLength(3)]
        [Required]
        public string Fullname { get; set; }
        public List<Book>? Books { get; set; }
    }
}
