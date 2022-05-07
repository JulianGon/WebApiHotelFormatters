using System.ComponentModel;

namespace WebApiHotel.clases
{
    public class HubFormatRequest
    {
        [DefaultValue("1")] // Dafault value for Swagger
        public int hotelId { get; set; }

        [DefaultValue("2018-10-20")]
        public string checkIn { get; set; }

        [DefaultValue("2018-10-25")]
        public string checkOut { get; set; }

        [DefaultValue("3")]
        public int numberOfGuests { get; set; }

        [DefaultValue("2")]
        public int numbetOfRooms { get; set; }

        [DefaultValue("EUR")]
        public string currency { get; set; }
    }
}
