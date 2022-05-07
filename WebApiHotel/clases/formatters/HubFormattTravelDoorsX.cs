using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiHotel.clases.apiProviders;
using WebApiHotel.interfaces.apis;

namespace WebApiHotel.clases.formatters
{
    public class HubFormattTravelDoorsX : HubFormatt
    {
        private TravelDoorsXApi apiTravelDoors;
        public HubFormattTravelDoorsX(IProvidersApi apiSearchers) : base(apiSearchers)
        {
            apiTravelDoors = (TravelDoorsXApi) apiSearchers;  
        }

        public override string formatReqAndRequest(HubFormatRequest json)
        {
            throw new NotImplementedException();
        }

        public override string formatRes(string json)
        {
            throw new NotImplementedException();
        }
    }
}
