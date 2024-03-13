using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Model
{
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  //Primary Key
        [ForeignKey("MusicCd")]
        public int MusicCDId { get; set; } // Foreign Key
        public MusicCD MusicCd { get; set; }
        public int UserId { get; set; }         
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } 
    }
}
