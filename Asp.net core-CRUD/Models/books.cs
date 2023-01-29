using System.ComponentModel.DataAnnotations;

namespace Asp.net_core_CRUD.Models
{
    public class books
    {
        public int ID { get; set; }
        [MinLength(3)]
        [MaxLength(150)]
        [Required]
        public string Title { get; set; } = "";
        public string? Language { get; set; }
        [MinLength(3)]
        [MaxLength(150)]
        public string Author { get; set; } = "";
        public DateTime PublishDate { get; set; }
        public int AvailableCopies { get; set; }
    }
}
