using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Models;

namespace backend.Mappers
{
    public static class ReportMappers
    {
        public static GetReportDto ToReportDtoFromReport(this Report report)
        {
            return new GetReportDto
            {
                Description = report.Description,
                Hours = report.Hours
            };
        }

        public static Report ToReportFromAddDto(this AddReportDto addReportDto)
        {
            return new Report
            {
                Description = addReportDto.Description,
                Hours = addReportDto.Hours,
            };
        }
    }
}