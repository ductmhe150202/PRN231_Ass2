using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        [ForeignKey("User_FK_Publisher_PubId")]
        public int PubId { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual Publisher Publisher { get; set; } = null!;
    }
}
