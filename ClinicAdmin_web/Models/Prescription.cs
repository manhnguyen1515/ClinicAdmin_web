using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            Invoices = new HashSet<Invoice>();
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
        }

        public int Id { get; set; }
        public string Doctor { get; set; }
        public string Staff { get; set; }
        public int? PatientId { get; set; }
        public DateTime? MedicalExamDay { get; set; }
        public string Diagnose { get; set; }
        public string MedicalHistory { get; set; }
        public string Symptom { get; set; }
        public string Note { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
