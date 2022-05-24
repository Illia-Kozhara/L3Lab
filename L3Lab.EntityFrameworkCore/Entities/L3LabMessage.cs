using System.ComponentModel.DataAnnotations;

namespace L3Lab.EntityFrameworkCore.Entities
{
    public class L3LabMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}