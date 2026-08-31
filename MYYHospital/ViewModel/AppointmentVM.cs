using MYYHospital.Models;

namespace MYYHospital.ViewModel
{
    public class AppointmentVM
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int DoctorId { get; set; }
        public List<Doctor> doctor { get; set; }
        public int PatientId { get; set; }
        public List<Patient> patient { get; set; }
    }
}
