using ClinicAdmin_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAdmin_web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Patient_Appointment> ListExams { get; set; }

        public double SumProfit { get; set; }
        public double ProfitInDay { get; set; }
        public int PatientInDay { get; set; }
        public int TotalInvoice { get; set; }
        public int TotalPatient { get; set; }
        public int TotalMedicine { get; set; }
    }

    public class Patient_Appointment
    {
        private static Patient_Appointment _instance;
        private int id;
        private DateTime appointmentDay;
        private int status;
        private Patient patient;

        public int Id { get => id; set => id = value; }
        public DateTime AppointmentDay { get => appointmentDay; set => appointmentDay = value; }
        public int Status { get => status; set => status = value; }
        public Patient Patient { get => patient; set => patient = value; }

        public static Patient_Appointment getInstance()
        {
            if (_instance == null)
            {
                _instance = new Patient_Appointment();
            }
            return _instance;
        }
    }
}
