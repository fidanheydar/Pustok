using System.ComponentModel.DataAnnotations;

namespace PustokMvc.Models
{
    public class BookImage:BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public int BookId { get; set; }
        public bool? Status { get; set; }
        public Book? Book { get; set; }
    }
}
