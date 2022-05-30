using System.ComponentModel.DataAnnotations;

namespace L3LabDotNetCore.Models
{
    public class NoteDTO
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Created { get; set; }

        
    }
}
