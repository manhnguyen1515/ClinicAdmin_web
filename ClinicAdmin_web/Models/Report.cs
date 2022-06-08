using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? TotalMedicines { get; set; }
        public int? TotalPatients { get; set; }
        public int? TotalInvoice { get; set; }
        public double? SumProfit { get; set; }
        public double? ProfitInDay { get; set; }
        public int? PatientInDay { get; set; }
        public string ReportPerson { get; set; }
        public string Descript { get; set; }
        public string Purpose { get; set; }
    }
}
