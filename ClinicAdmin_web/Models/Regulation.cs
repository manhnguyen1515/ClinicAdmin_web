using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAdmin_web.Models
{
    public partial class Regulation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Datatypes { get; set; }
        public string Value { get; set; }
        public int? Status { get; set; }
    }
}
