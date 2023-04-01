namespace ScheduleApp.Entities
{
    public class ScheduleSeeder
    {
        private readonly ScheduleDbContext _context;
        public ScheduleSeeder(ScheduleDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Services.Any())
                {
                    var Services = GetServices();
                    _context.Services.AddRange(Services);
                    _context.SaveChanges();
                }
                if (!_context.Appointments.Any())
                {
                    var Appointments = GetAppointments();
                    _context.Appointments.AddRange(Appointments);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Appointment> GetAppointments()
        {


            var appointments = new List<Appointment>()
            {
                new Appointment()
                {
                    AppointmentStart = new DateTime(2023,04,11,12,30,00),
                    AppointmentEnd = new DateTime(2023,04,11,13,30,00),
                    Client = new Client()
                    {
                        Name= "Janina",
                        LastName="Kciuk",
                        PhoneNumber="600300400",
                        Adress= new Adress()
                        {
                            City="Mikolow",
                            Street="Krakowska",
                            Number="2",
                            PostalCode="44-190",
                        }
                    },
                    Service = _context.Services.FirstOrDefault(a=>a.ServiceName=="Makijaz Ślubny")
                },
                new Appointment()
                {
                    AppointmentStart = new DateTime(2023,04,11,14,00,00),
                    AppointmentEnd = new DateTime(2023,04,11,15,30,00),
                    Client = new Client()
                    {
                        Name= "Barbara",
                        LastName="Kania",
                        PhoneNumber="620500450",
                        Adress= new Adress()
                        {
                            City="Orzesze",
                            Street="Wawrzyńca",
                            Number="55",
                            PostalCode="43-180",
                        }
                    },
                    Service = _context.Services.FirstOrDefault(a=>a.ServiceName=="Makijaz Okolicznosciowy")
                },
                new Appointment()
                {
                    AppointmentStart = new DateTime(2023,04,12,14,00,00),
                    AppointmentEnd = new DateTime(2023,04,12,15,30,00),
                    Client = new Client()
                    {
                        Name= "Małgorzata",
                        LastName="Kowalska",
                        PhoneNumber="603999888",
                        Adress= new Adress()
                        {
                            City="Orzesze",
                            Street="Katowicka",
                            Number="4",
                            PostalCode="43-180",
                        }
                    },
                    Service = _context.Services.FirstOrDefault(a=>a.ServiceName=="Makijaz Okolicznosciowy")
                },
                new Appointment()
                {
                    AppointmentStart = new DateTime(2023,04,13,14,00,00),
                    AppointmentEnd = new DateTime(2023,04,13,15,30,00),
                    Client = new Client()
                    {
                        Name= "Aneta",
                        LastName="Nowak",
                        PhoneNumber="603899888",
                        Adress= new Adress()
                        {
                            City="Orzesze",
                            Street="Wiejska",
                            Number="4",
                            PostalCode="43-180",
                        }
                    },
                    Service = _context.Services.FirstOrDefault(a=>a.ServiceName=="Henna")
                }
            };

            return appointments;
        }

        private static IEnumerable<Service> GetServices()
        {
            var services = new List<Service>()
            {
                new Service()
                {
                    ServiceName="Makijaz Ślubny",
                    Description="Ślubny",
                    Price=160
                },
                new Service()
                {
                    ServiceName="Makijaz Okolicznosciowy",
                    Description="Okolicznosciowy",
                    Price=160
                },
                new Service()
                {
                    ServiceName="Henna",
                    Description="Henna Pudorwa",
                    Price=90
                }
            };
            return services;
        }
    }
}
