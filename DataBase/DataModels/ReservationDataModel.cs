using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Reservations")]
    public class ReservationDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Customer")]
        public CustomerDataModel Customer { get; set; }

        [Required]
        [Column("Room")]
        public RoomDataModel Room { get; set; }

        public int PersonCount { get; set; }

        [Required]
        public bool WithBreakfast { get; set; }

        [Required]
        public DateTime StartDatePlanned { get; set; }

        [Required]
        public DateTime EndDatePlanned { get; set; }

        public DateTime StartDateReal { get; set; }

        public DateTime EndDateReal { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
