using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial10.Models
{
    public class Prescription_Medicament
    {
        [Key]
        public int IdPrescription_Medicament { get; set; }
        public int IdMedicament { get; set; }
        
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }
    }
}
