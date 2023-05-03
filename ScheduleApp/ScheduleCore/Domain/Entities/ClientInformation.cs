using ScheduleCore.Domain.Entities;

namespace ScheduleCore.Entities
{
    internal class ClientInformation
    {
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            ClientInformation other = (ClientInformation)obj;
            if (this.Name == other.Name && this.LastName == other.LastName
                && this.PhoneNumber == other.PhoneNumber)
            {
                return true;
            }
            return false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AdressId { get; set; }
        public virtual Address Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string? Remarks { get; set; }
        public virtual List<Appointment>? Appointments { get; set; }
    }
}