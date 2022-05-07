using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHotel.clases.json.providers
{
    public class HotelLegsRequestJson
    {
        public int hotel;
        public string checkInDate = "";
        public string numberOfNights = "";
        public int guests;
        public int rooms;
        public string currency = "";
        
    }
}
