using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private ICollection<Report> _reports = new List<Report> {
                new Report {
                    Description= "First Report",
                    Hours = 2.5
                },
                new Report {
                    Description= "Second Report",
                    Hours = 3
                }
            };


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // // currently not using await as we don't have a server...
            // var reports = new List<Report> {
            //     new Report {
            //         Description= "First Report",
            //         Hours = 2.5
            //     },
            //     new Report {
            //         Description= "Second Report",
            //         Hours = 3
            //     }
            // };

            var reportsToReturn = _reports.Select(r => r.ToReportDtoFromReport());

            // return the reports + successfull status code (200)
            return Ok(reportsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddReportDto reportToAdd)
        {
            _reports.Add(reportToAdd.ToReportFromAddDto());

            // return successful created status code (201)
            return CreatedAtAction(nameof(GetAll), new { }, _reports.ToList());
        }


    }
}