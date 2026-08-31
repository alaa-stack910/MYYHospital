namespace MYYHospital.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Appointment> appointments { get; set; }

    }
}
