using L3LabDotNetCore.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace L3Lab.EntityFrameworkCore.Entities
{
    public class Note
    {
        public Note (string content, DateTime created)
        {
            Content = content;
            Created = created;
        }
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Created { get; set; }
        
    }
}