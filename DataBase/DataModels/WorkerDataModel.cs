using DataBase.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Workers")]
    public class WorkerDataModel
    {
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public WorkerType Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        public Gender? Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public override string ToString()
        {
            return $"{Name} {Lastname} - {Type}";
        }
    }
}
