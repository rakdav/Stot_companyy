using System.ComponentModel.DataAnnotations;

namespace Blazzer.DataAccess.Entity
{
    public class CreateWorkerModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string? NameWorker {  get; set; }

        [Required(ErrorMessage = "Last_Name is required")]
        public string? LastNameWorker { get; set; }
        
        
        [Required(ErrorMessage = "Post is required")]
        public string? Post {  get; set; }

        [Required(ErrorMessage = "Name Company is required")]
        public string? NameComp { get; set; }

        [Required(ErrorMessage = "Id is required")]

        public int IdWorker { get; set; }


    }
}
