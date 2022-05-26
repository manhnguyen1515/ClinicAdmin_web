using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public double? TotalCost { get; set; }
        public double? ExaminationFee { get; set; }
        public double? DrugFee { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
