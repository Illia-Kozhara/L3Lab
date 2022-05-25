using System.ComponentModel.DataAnnotations;

namespace L3Lab.EntityFrameworkCore.Entities
{
    public class Note 
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        
    }
}