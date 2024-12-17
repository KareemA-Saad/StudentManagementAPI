using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Model
{
 
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(5, 18)]
        public int Age { get; set; }

        [Required]
        [RegularExpression("Grade 1|Grade 2|Grade 3", ErrorMessage = "Grade must be 'Grade 1', 'Grade 2', or 'Grade 3'")]
        public string Grade { get; set; }

        public bool IsDeleted { get; set; } = false; // Soft Delete
    }
}

