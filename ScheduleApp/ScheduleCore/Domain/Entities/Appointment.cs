using ScheduleCore.CommandHandler;
using ScheduleCore.Entities;

namespace ScheduleCore.Domain.Entities
{
    internal class Appointment : IAppointment
    {
        internal Appointment() { }

        private Appointment(DateTime appointmentStart, DateTime appointmentEnd, Service Service, string? remarks, ClientInformation ClientInformation)
        {
            AppointmentStart = appointmentStart;
            AppointmentEnd = appointmentEnd;
            this.Service = Service;
            Remarks = remarks;
            this.ClientInformation = ClientInformation;
        }

        private Appointment(DateTime appointmentStart, DateTime appointmentEnd, int serviceId, string? remarks, int clientInformationsId)
        {
            AppointmentStart = appointmentStart;
            AppointmentEnd = appointmentEnd;
            ServiceId = serviceId;
            Remarks = remarks;
            ClientInformationsId = clientInformationsId;
        }

        public static async Task<Appointment> Create(
            ITermsValidator validator,
            DateTime appointmentStart, 
            DateTime appointmentEnd, 
            int serviceId, 
            string? remarks, 
            int clientInformationsId, 
            CancellationToken ct)
        {
            await validator.ValidateAsync(appointmentStart, appointmentEnd, ct);
            return new Appointment(appointmentStart, appointmentEnd, serviceId, remarks, clientInformationsId);
        }

        internal static Appointment CreateForce(
            DateTime appointmentStart,
            DateTime appointmentEnd,
            Service Service,
            string? remarks,
            ClientInformation ClientInformation)
        {
            return new Appointment(appointmentStart, appointmentEnd, Service, remarks, ClientInformation);
        }

        public int Id { get; private set; }
        public DateTime AppointmentStart { get; private set; }
        public DateTime AppointmentEnd { get; private set; }
        public int ServiceId { get; private set; }
        public virtual Service? Service { get; private set; }
        public string? Remarks { get; private set; }
        public int ClientInformationsId { get; private set; }
        public virtual ClientInformation? ClientInformation { get; private set; }
    }
}

