using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiHotel.clases.json.hub;
using WebApiHotel.interfaces.apis;
using WebApiHotel.interfaces.formatters;

namespace WebApiHotel.clases.formatters
{
    /// <summary>
    /// Abstract class for different format of API providers
    /// </summary>
    public abstract class HubFormatt : IHubFormatt
    {
        private IProvidersApi _apiSearchers;

        /// <summary>
        /// Load appropriate API
        /// </summary>
        /// <param name="apiProvider">IProvidersApi</param>
        public HubFormatt(IProvidersApi apiSearchers) { 
            this._apiSearchers = apiSearchers;
        }
        public abstract string formatReqAndRequest(HubFormatRequest json);

        public abstract string formatRes(string json);
    }
}
