using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDay { get; set; }
        public int PatientId { get; set; }
        public int Status { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
