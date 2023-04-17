﻿using MediatR;
using ScheduleCore.Primitives;

namespace ScheduleCore.Command
{
    public static class CreateAppointment
    {
        public record Command(int ClientInformationsId, int ServiceId,
            DateTime AppointmentStart, DateTime AppointmentEnd, string? Remarks) : ICommand<int>
        {
        }
    }
}