using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos;
using backend.Interfaces;
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

        private readonly IReportsRepository _reportsRepository;

        public ReportsController(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // var reportsToReturn = _reports.Select(r => r.ToReportDtoFromReport());
            var reportsToReturn = await _reportsRepository.GetAllAsync();

            // Converting the Model to Dto
            reportsToReturn.Select(reportModel => reportModel.ToGetReportDtoFromReport());

            // return the reports + successfull status code (200)
            return Ok(reportsToReturn);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // TBD - add here validation for the request using ModelState.IsValid

            var report = await _reportsRepository.GetById(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddReportDto reportToAdd)
        {
            // Todo: add here validatio check using ModelState.IsValid

            var reportModel = await _reportsRepository.CreateAsync(reportToAdd.ToReportFromAddDto());

            // return successful created status code (201) + the created report (with it's id)
            return CreatedAtAction(nameof(GetById), new { id = reportModel.Id }, reportModel.ToGetReportDtoFromReport());
        }
    }
}