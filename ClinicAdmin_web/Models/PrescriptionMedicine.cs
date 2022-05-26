using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class PrescriptionMedicine
    {
        public int Id { get; set; }
        public int? PrescriptionId { get; set; }
        public int? MedicineId { get; set; }
        public int? AmountDrug { get; set; }
        public double? Cost { get; set; }
        public int? Unit { get; set; }
        public int? Usage { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual UnitMedicine UnitNavigation { get; set; }
        public virtual UsageMedicine UsageNavigation { get; set; }
    }
}
