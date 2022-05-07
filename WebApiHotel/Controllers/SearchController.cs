using Microsoft.AspNetCore.Mvc;
using WebApiHotel.clases;
using WebApiHotel.clases.apiProviders;
using WebApiHotel.clases.formatters;
using WebApiHotel.interfaces.apis;
using WebApiHotel.interfaces.formatters;

namespace WebApiHotel.Controllers
{
    [ApiController]
    [Route("hubHoteles/search")]
    public class SearchController : ControllerBase
    {
        IHubFormatt adapter;
        IProvidersApi[] apis = { new HotelLegsApi(), new TravelDoorsXApi(), new SpeediaApi() };

        string responseAll;
        public SearchController()
        {
        }

        [HttpPost]
        //public  Task<ActionResult<List<HubFormatRequest>>> Post (HubFormatRequest req)
        public string Post(HubFormatRequest req)
        {
            foreach (IProvidersApi api in apis)
            {
                try
                {
                    if (api.GetType().Equals(typeof(HotelLegsApi)))
                    {
                        Console.WriteLine("\nConecting to HotelLegs");
                        adapter = new HubFormattHotellegs(api);
                    }
                    else if (api.GetType().Equals(typeof(TravelDoorsXApi)))
                    {
                        Console.WriteLine("\nConecting to TravelDoors");
                        adapter = new HubFormattTravelDoorsX(api);
                    }
                    else if (api.GetType().Equals(typeof(SpeediaApi)))
                    {
                        Console.WriteLine("\nConecting to Speedia");
                        adapter = new HubFormattSpeedia(api);
                    }


                    if (adapter != null)
                    {
                        string res =  adapter.formatReqAndRequest(req);
                        string resHub = adapter.formatRes(res);
                        Console.WriteLine("The response with the data is received: -> {0}", resHub);
                        responseAll += resHub;
                        adapter = null;
                    }
                    else
                    {
                        // New Api providers added but it not have adapter
                        Console.WriteLine($"Non-existent Apis provider: { api.GetType().ToString()}");
                    }

                }
                catch (Newtonsoft.Json.JsonException ex)
                { // Exception generated during serialization or deserialization JSON on adapter.formatReqAndRequest() or formatRes()
                    Console.WriteLine(ex.Message);
                }
                catch (NotImplementedException ex)
                {
                    Console.WriteLine($"Non-existent implementation of: {ex.StackTrace}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General exception: {ex}");
                }
            }
            Console.WriteLine("\nComplete Respone: -> {0}", responseAll);
            return responseAll;

        }
    }
}
