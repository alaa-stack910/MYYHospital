using Microsoft.AspNetCore.Mvc;
using MYYHospital.Models;
using MYYHospital.Repo.Implement;
using MYYHospital.Repo.Interface;
using MYYHospital.ViewModel;

namespace MYYHospital.Controllers
{
    public class AppointmentController:Controller
    {

        private readonly IDoctor doctor;
        private readonly IPatient patient;
        private readonly IAppointment appointment;

        public AppointmentController(IDoctor doctor ,IPatient patient,IAppointment appointment)
        {
            this.doctor = doctor;
            this.patient = patient;
            this.appointment = appointment;
        }
        public IActionResult Index()
        {
            var d = appointment.GetAll();
            return View(d);
        }


        [HttpGet]

        public IActionResult Create()
        {
            var vm = new AppointmentVM
            {
                patient = patient.GetAll(),
                doctor = doctor.GetAll()
            };

            return View(vm);
        }

        [HttpPost]

        public IActionResult Create(AppointmentVM vm)
        {
            var a = new Appointment
            {
                AppointmentId = vm.AppointmentId,
                PatientId = vm.PatientId,
                DoctorId = vm.DoctorId,
                Notes = vm.Notes,
                Date = vm.Date,
            };
            appointment.Add(a);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]

        public IActionResult Edit(int id)
        {
            var s = appointment.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            var a = new AppointmentVM
            {
                AppointmentId = s.AppointmentId,
                PatientId = s.PatientId,
                DoctorId = s.DoctorId,
                Notes = s.Notes,
                Date = s.Date,
                patient = patient.GetAll(),
                doctor = doctor.GetAll(),
            };


            return View(a);
        }

        [HttpPost]

        public IActionResult Edit(AppointmentVM vm)
        {
            var s = appointment.GetId(vm.AppointmentId);
            if (s == null)
            {
                return NotFound();
            }
            s.AppointmentId = vm.AppointmentId;
            s.PatientId = vm.PatientId;
            s.DoctorId = vm.DoctorId;
            s.Notes = vm.Notes;
            s.Date = vm.Date;
            appointment.Update(s);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var s = appointment.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            appointment.Delete(s);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var s = appointment.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }

    }
}
