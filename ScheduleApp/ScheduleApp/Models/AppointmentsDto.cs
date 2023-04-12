namespace ScheduleCore.Models
{
    public class AppointmentsDto
    {

        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }
        public string? Remarks { get; set; }
        public int Id { get; set; }

        public string ServiceName { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? ClientRemarks { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

    }
}
