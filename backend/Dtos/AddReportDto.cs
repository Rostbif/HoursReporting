using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos
{
    public class AddReportDto
    {
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description can't be longer than 100 characters")]

        public string? Description { get; set; }
        [Required(ErrorMessage = "Hours are required")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Hours must be greater than 0")]
        public double Hours { get; set; }
    }
}