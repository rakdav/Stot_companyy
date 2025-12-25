
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Stot_company.DataAss.Entity
{
    public class Const_Comp
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComp { get; set; }
        [Required]
        public string? NameComp { get; set; }
        [Required]
        public string? WorkPrice { get; set; }
        [Required]
        public string? Location { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
    }
}
