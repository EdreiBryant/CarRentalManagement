namespace CarRentalManagement.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string? DrivingLicense { get; set; }
        public string? Address { get; set;}
        public string? ContactNumber { get; set;}
        public string? EmailAddress { get; set;}
        //public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        //public string? CreatedBy { get; set; }
        //public string? UpdatedBy { get; set; }
        public virtual List<Booking>? Bookings { get; set; }
    }
}