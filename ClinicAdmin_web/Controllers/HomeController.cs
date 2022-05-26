using ClinicAdmin_web.Middlewares;
using ClinicAdmin_web.Models;
using ClinicAdmin_web.Services;
using ClinicAdmin_web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAdmin_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClinicAdminWebContext _context;

        public HomeController(ILogger<HomeController> logger, ClinicAdminWebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel mymodel = new HomeViewModel();
            mymodel.Appointments = _context.Appointments.ToList();
            mymodel.ListExams = HomeService.getInstance().GetListExams();
            mymodel.SumProfit = _context.Invoices.Sum(i => i.TotalCost).Value;
            //mymodel.ProfitInDay = _context.Invoices.Where(i => i.CreatedAt.Value.DayOfWeek == DateTime.Now.DayOfWeek).Sum(i => i.TotalCost).Value;
            //mymodel.PatientInDay = _context.Appointments.Where(i => i.AppointmentDay.DayOfWeek == DateTime.Now.DayOfWeek).Count();
            mymodel.TotalPatient = _context.Patients.Count();
            mymodel.TotalInvoice = _context.Invoices.Count();
            mymodel.TotalMedicine = _context.Medicines.Count();
            
            return View(mymodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
