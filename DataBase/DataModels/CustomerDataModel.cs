using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Customers")]
    public class CustomerDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
