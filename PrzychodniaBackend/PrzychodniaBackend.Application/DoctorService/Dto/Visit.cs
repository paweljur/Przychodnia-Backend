using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.DoctorService.Dto
{
    public class Visit
    {
        public long Id { get; set; }
        public Appointment Appointment { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }

        internal Visit(VisitEntity visit)
        {
            Id = visit.Id;
            Appointment = new Appointment(visit.Appointment);
            Description = visit.Description;
            Diagnosis = visit.Diagnosis;
        }
    }
}