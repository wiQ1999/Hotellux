using DataBase.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Cleanings")]
    public class CleaningsDataModel
    {
        [Key]
        public int Id { get; set; }

        public TaskState State { get; set; }
        
        public WorkerDataModel Creator { get; set; }

        public WorkerDataModel Executor { get; set; }

        public RoomDataModel Room { get; set; }

        public string CreatorDescription { get; set; }

        public string ExecutorDescription { get; set; }

        public DateTime StartDatePlanned { get; set; }

        public DateTime? EndDatePlanned { get; set; }
        
        public DateTime? StartDateReal { get; set; }
        
        public DateTime? EndDateReal { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
