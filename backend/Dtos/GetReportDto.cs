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
        public double Hours { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}