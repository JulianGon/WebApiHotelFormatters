using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHotel.clases.json.hub
{
    public class HubRateResponseJson
    {
        public int mealPlanId;
        public bool isCancellable;
        public double price;
    }
    public class HubRoomResponseJson
    {
        public int roomId;
        public List<HubRateResponseJson>? rates;
    }
}
