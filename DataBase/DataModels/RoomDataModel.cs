﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Rooms")]
    public class RoomDataModel
    {
        [Key]
        public int Id { get; set; }

        public int Floor { get; set; }

        public int Number { get; set; }

        public int Capacity { get; set; }

        public float Size { get; set; }

        [Required]
        public double PricePerDay { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}