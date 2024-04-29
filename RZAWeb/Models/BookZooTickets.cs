using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RZAWeb.Models
{
    public class BookZooTickets
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Booking date")]
        public DateTime BookingDate { get; set; }
        [Display(Name = "Child tickets")]
        public int ChildTickets { get; set; }
        [Display(Name = "Adult tickets")]
        public int AdultTickets { get; set;}
        [Display(Name = "Time of booking")]
        [DataType(DataType.DateTime)]
        public DateTime BookingTime { get; set; }
        public string? UserID { get; set; }
    }
}
