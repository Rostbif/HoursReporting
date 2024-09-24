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
        private readonly IReportsRepository _reportsRepository;

        public ReportsController(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        /// <summary>
        /// Get all reports
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reportsToReturn = await _reportsRepository.GetAllAsync();

            // Converting the Models to Dtos before sending it back to the client
            reportsToReturn.Select(reportModel => reportModel.ToGetReportDtoFromReport());

            // return the reports + successfull status code (200)
            return Ok(reportsToReturn);
        }

        /// <summary>
        /// Get a single report by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var report = await _reportsRepository.GetById(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        /// <summary>
        /// Create a new report
        /// </summary>
        /// <param name="reportToAdd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(AddReportDto reportToAdd)
        {
            var reportModel = await _reportsRepository.CreateAsync(reportToAdd.ToReportFromAddDto());

            // return successful created status code (201) + the created report (with it's id)
            return CreatedAtAction(nameof(GetById), new { id = reportModel.Id }, reportModel.ToGetReportDtoFromReport());
        }
    }
}