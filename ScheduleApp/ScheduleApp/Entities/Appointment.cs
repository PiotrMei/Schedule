using ScheduleApp.CommandHandler;

namespace ScheduleApp.Entities
{
    internal class Appointment : IAppointment
    {
        private Appointment() { }

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

        internal static Appointment CreateForce()
        {
            return new Appointment();
        }

        public int Id { get; private set; }
        public DateTime AppointmentStart { get; private set; }
        public DateTime AppointmentEnd { get; private set; }
        public int ServiceId { get; private set; }
        public virtual Service? Service { get; private set; }
        public string? Remarks { get; private set; }
        public int ClientInformationsId { get; private set; }
        public virtual ClientInformations? ClientInformations { get; private set; }
    }
}

