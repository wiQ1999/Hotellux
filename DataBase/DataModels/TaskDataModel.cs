using DataBase.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Tasks")]
    public class TaskDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Creator")]
        public WorkerDataModel Creator { get; set; }

        [Column("Excecutor")]
        public WorkerDataModel Excecutor { get; set; }

        [Column("ExcecutorType")]
        public WorkerType? ExcecutorType { get; set; }

        public State State { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDatePlanned { get; set; }

        [Required]
        public DateTime EndDatePlanned { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
