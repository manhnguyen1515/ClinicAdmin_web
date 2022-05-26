using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
        }

        public int Id { get; set; }
        public string DrugName { get; set; }
        public int Storage { get; set; }
        public double Price { get; set; }

        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
