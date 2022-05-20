using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseAFS.Models
{
    public class Role
    {
        [Key]
        public byte RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
