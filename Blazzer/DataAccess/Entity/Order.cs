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
        public override string ToString()
        {
            return $"IdOrder: {IdOrder},\n" +
                $"Name_Order: {NameOrder},\n" +
                $"Date_Order: {DateOrder},\n" +
                $"Price: {Price},\n" +
                $"IdClient: {IdClient},\n";
        }
    }
}
