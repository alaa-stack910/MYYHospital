namespace MYYHospital.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
}
