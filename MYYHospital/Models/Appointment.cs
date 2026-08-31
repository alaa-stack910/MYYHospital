using Microsoft.VisualBasic;
using MYYHospital.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MYYHospital.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string Notes {  get; set; }
        public int DoctorId { get; set; }
        public Doctor doctor { get; set; }
        public int PatientId { get; set; }
        public Patient patient { get; set; }

    }
}
