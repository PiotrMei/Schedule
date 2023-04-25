﻿using AutoMapper;
using ScheduleCore.Domain.Entities;
using ScheduleCore.QueryHandlers;
namespace ScheduleCore.QueryHandlers
{
    internal class ScheduleMappingProfile : Profile
    {
        internal ScheduleMappingProfile()
        {
            CreateMap<Appointment, AppointmentsDto>()
                .ForMember(m => m.City, c => c.MapFrom(d => d.ClientInformation.Adress.City))
                .ForMember(m => m.Street, c => c.MapFrom(d => d.ClientInformation.Adress.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(d => d.ClientInformation.Adress.PostalCode))
                .ForMember(m => m.Number, c => c.MapFrom(d => d.ClientInformation.Adress.Number))
                .ForMember(m => m.ServiceName, c => c.MapFrom(d => d.Service.ServiceName))
                .ForMember(m => m.Description, c => c.MapFrom(d => d.Service.Description))
                .ForMember(m => m.Price, c => c.MapFrom(d => d.Service.Price))
                .ForMember(m => m.Name, c => c.MapFrom(d => d.ClientInformation.Name))
                .ForMember(m => m.LastName, c => c.MapFrom(d => d.ClientInformation.LastName))
                .ForMember(m => m.ClientRemarks, c => c.MapFrom(d => d.ClientInformation.Remarks))
                .ForMember(m => m.PhoneNumber, c => c.MapFrom(d => d.ClientInformation.PhoneNumber));
        }
    }
}
