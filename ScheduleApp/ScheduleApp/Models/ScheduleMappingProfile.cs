﻿using AutoMapper;
using ScheduleApp.Entities;

namespace ScheduleApp.Models
{
    public class ScheduleMappingProfile : Profile
    {
        public ScheduleMappingProfile()
        {
            CreateMap<Appointment, AppointmentsDto>()
                .ForMember(m => m.City, c => c.MapFrom(d => d.ClientInformations.Adress.City))
                .ForMember(m => m.Street, c => c.MapFrom(d => d.ClientInformations.Adress.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(d => d.ClientInformations.Adress.PostalCode))
                .ForMember(m => m.Number, c => c.MapFrom(d => d.ClientInformations.Adress.Number))
                .ForMember(m => m.ServiceName, c => c.MapFrom(d => d.Service.ServiceName))
                .ForMember(m => m.Description, c => c.MapFrom(d => d.Service.Description))
                .ForMember(m => m.Price, c => c.MapFrom(d => d.Service.Price))
                .ForMember(m => m.Name, c => c.MapFrom(d => d.ClientInformations.Name))
                .ForMember(m => m.LastName, c => c.MapFrom(d => d.ClientInformations.LastName))
                .ForMember(m => m.ClientRemarks, c => c.MapFrom(d => d.ClientInformations.Remarks))
                .ForMember(m => m.PhoneNumber, c => c.MapFrom(d => d.ClientInformations.PhoneNumber));
        }
    }
}
