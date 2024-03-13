using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Model.DTO
{
    public class MusicCDDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Primary Key
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
    }
}
