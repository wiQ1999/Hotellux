using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.DataModels
{
    [Table("Logins")]
    public class LoginDataModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public WorkerDataModel Worker { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
