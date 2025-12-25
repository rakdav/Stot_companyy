using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stot_company.DataAss.Entity
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }
        [Required]
        public string? NameClient { get; set; }
        [Required]
        public string? LastNameClient { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime ArrearsClient {  get; set; }
        public decimal? Payment {  get; set; }
        [Required]
        [Range(minimum:18, maximum:80)]
        public int Age { get; set; }
        [Required]
        public int Passport { get; set; }
        [Required]
        public string? Sex { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
