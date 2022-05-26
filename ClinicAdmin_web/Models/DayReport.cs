using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class DayReport
    {
        public int Id { get; set; }
        public DateTime? DayReport1 { get; set; }
        public int? TotalMedicines { get; set; }
        public int? TotalPatients { get; set; }
        public int? TotalInvoice { get; set; }
    }
}
