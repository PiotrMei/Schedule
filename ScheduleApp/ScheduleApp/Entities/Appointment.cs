﻿namespace ScheduleApp.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public string? Remarks { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}

