using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Model
{
    public class MusicCD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //Primary Key
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
