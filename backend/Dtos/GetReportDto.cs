using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos
{
    public class GetReportDto
    {
        public required string Description { get; set; }
        public double Hours { get; set; }
    }
}