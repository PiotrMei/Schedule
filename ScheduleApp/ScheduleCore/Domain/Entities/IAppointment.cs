﻿namespace ScheduleCore.Entities
{
    public interface IAppointment
    {
        DateTime AppointmentEnd { get; }
        DateTime AppointmentStart { get; }
    }
}