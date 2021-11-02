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

        public CustomerDataModel Customer { get; set; }

        public RoomDataModel Room { get; set; }

        public int PersonCount { get; set; }

        public bool WithBreakfast { get; set; }

        public DateTime StartDatePlanned { get; set; }

        public DateTime EndDatePlanned { get; set; }

        public DateTime? StartDateReal { get; set; }

        public DateTime? EndDateReal { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
