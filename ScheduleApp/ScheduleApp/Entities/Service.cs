﻿namespace ScheduleApp.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public virtual List<Appointment>? Appointments { get; set; }
    }
}