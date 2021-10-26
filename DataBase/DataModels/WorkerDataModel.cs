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

        [Required]
        public WorkerType WorkerType { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirdth { get; set; }

        public string Email { get; set; }

        [MaxLength(15)]
        public string PhonNumber { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
