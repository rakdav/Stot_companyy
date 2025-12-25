using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stot_company.DataAss.Entity
{
    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWorker { get; set; }
        [Required]
        public string? NameWorker { get; set; }
        [Required]
        public string? LastNameWorker { get; set; }
        public string? Post { get; set; }
        public int IdComp {  get; set; }
        public virtual Const_Comp IdCompNavigation { get; set; } = null!;
    }
}
