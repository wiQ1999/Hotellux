using DataBase.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Action")]
    public class ActionDataModel
    {
        [Key]
        public int Id { get; set; }

        [Column("Task")]
        public TaskDataModel Task { get; set; }

        [Column("Excecutor")]
        public WorkerDataModel Excecutor { get; set; }

        public State State { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDateReal { get; set; }

        [Required]
        public DateTime EndDateReal { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
