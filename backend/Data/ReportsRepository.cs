using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly AppDbContext _context;

        public ReportsRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<List<Report>> GetAllAsync()
        {
            var reports = await _context.Reports.ToListAsync();

            return reports;
        }


        public async Task<Report?> GetById(int id)
        {
            return await _context.Reports.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Report> CreateAsync(Report reportToAdd)
        {
            // Add to the list.
            // This method only begins tracking the given entity and put the entity
            // in the EntityState.Added state such that they will be inserted into the database when DbContext.SaveChanges() is called.
            await _context.Reports.AddAsync(reportToAdd);

            // Save in order to trigger updating the db with the tracked item.
            await _context.SaveChangesAsync();

            return reportToAdd;
        }



    }
}