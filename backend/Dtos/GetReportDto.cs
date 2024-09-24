using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos
{
    public class GetReportDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        // Currently the UI support only whole number. in the future we will support also not whole hours. 
        public double Hours { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}