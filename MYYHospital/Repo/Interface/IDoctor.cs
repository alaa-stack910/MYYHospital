using MYYHospital.Models;

namespace MYYHospital.Repo.Interface
{
    public interface IDoctor
    {
        public List<Doctor> GetAll();
        public Doctor GetId(int id);
        public void Add(Doctor doctor);
        public void Delete(Doctor doctor);
        public void Update (Doctor doctor);
    }
}
