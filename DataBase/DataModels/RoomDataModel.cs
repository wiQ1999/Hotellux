using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Rooms")]
    public class RoomDataModel
    {
        [Key]
        public int Id { get; set; }

        public int Floor { get; set; }

        [Required]
        public string Number { get; set; }

        public float Size { get; set; }

        public int Capacity { get; set; }

        public decimal PricePerDay { get; set; }

        public string Description { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
