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
        public static GetReportDto ToGetReportDtoFromReport(this Report report)
        {
            return new GetReportDto
            {
                Id = report.Id,
                Description = report.Description,
                Hours = report.Hours,
                CreatedAt = report.CreatedAt
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