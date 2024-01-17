using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Registration
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; }
        public bool? IsDeleted { get; set; }
    }
}
