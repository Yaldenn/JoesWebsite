using System.ComponentModel.DataAnnotations;

namespace RZAWeb.Models
{
    public class BookHotelRooms
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Booking date")]
        public DateTime BookingDate { get; set; }
        [Display(Name = "Family Rooms")]
        public int FamilyRooms { get; set; }
        [Display(Name = "Double Rooms")]
        public int DoubleRooms { get; set; }
        [Display(Name = "Single Rooms")]
        public int SingleRooms { get; set; }
        [Display(Name = "Time of booking")]
        [DataType(DataType.DateTime)]
        public DateTime BookingTime { get; set; }
        public string? UserID { get; set; }
    }
}
