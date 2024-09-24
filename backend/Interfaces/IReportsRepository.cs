using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Controllers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IReportsRepository
    {
        Task<List<Report>> GetAllAsync();
        Task<Report?> GetById(int id);
        Task<Report> CreateAsync(Report reportToAdd);
    }
}