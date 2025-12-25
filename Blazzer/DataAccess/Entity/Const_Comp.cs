
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

        public int IdOrder { get; set; }

        public override string ToString()
        {
            return $"IdComp: {IdComp},\n" +
                $"Name_Comp: {NameComp},\n" +
                $"Work_Price: {WorkPrice},\n" +
                $"Location: {Location},\n" +
                $"IdOrder: {IdOrder},\n";
        }

    }
}
