using WebApiHotel.clases;

namespace WebApiHotel.interfaces.formatters
{
    public interface IHubFormatt
    {
        public string formatReqAndRequest(HubFormatRequest json);
        public string formatRes(string json);
    }
}
