using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stot_company.DataAss.Entity
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }
        [Required]
        public string? NameOrder { get; set; }
        [Required]
        public DateTime DateOrder { get; set; }
        [Required]
        public int Price { get; set; }
        public int IdClient { get; set; }
        public int IdComp { get; set; }
        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Const_Comp IdCompNavigation { get; set; } = null!;
    }
}
