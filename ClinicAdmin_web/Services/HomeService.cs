using ClinicAdmin_web.Models;
using ClinicAdmin_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAdmin_web.Services
{
    public class HomeService
    {
        private static HomeService _instance;
        private readonly ClinicAdminWebContext _context;

        public HomeService()
        {
            _context = new ClinicAdminWebContext();
        }

        public static HomeService getInstance()
        {
            if (_instance == null)
            {
                _instance = new HomeService();
            }
            return _instance;
        }

        public List<Patient_Appointment> GetListExams()
        {
            List<Patient_Appointment> listExams = new List<Patient_Appointment>();
            var entry = (from pt in _context.Patients
                         join ap in _context.Appointments on pt.Id equals ap.PatientId
                         where ap.Status == 0
                         select new
                         {
                             patientId = pt.Id,
                             FullName = pt.FullName,
                             Address = pt.Address,
                             Phone = pt.Phone,
                             Weight = pt.Weight,
                             Age = pt.Age,
                             Gender = pt.Gender,
                             appId = ap.Id,
                             Day = ap.AppointmentDay,
                             Status = ap.Status
                         }).ToList();
            foreach (var item in entry)
            {
                Patient patient = new Patient()
                {
                    Id = item.patientId,
                    FullName = item.FullName,
                    Address = item.Address,
                    Phone = item.Phone,
                    Weight = item.Weight,
                    Age = item.Age,
                    Gender = item.Gender
                };
                Patient_Appointment appointment = new Patient_Appointment()
                {
                    Id = item.appId,
                    AppointmentDay = item.Day,
                    Status = item.Status,
                    Patient = patient
                };
                listExams.Add(appointment);
            }

            return listExams;
        }
    }
}
