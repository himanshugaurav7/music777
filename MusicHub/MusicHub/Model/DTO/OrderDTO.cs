using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Model.DTO
{
    public class OrderDTO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  //Primary Key
        [ForeignKey("MusicCd")]
        [Required]
        public int MusicCDId { get; set; } // Foreign Key
        public MusicCD MusicCd { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }

    }
}
