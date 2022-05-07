using Newtonsoft.Json;
using WebApiHotel.clases.json.providers;
using WebApiHotel.interfaces.apis;

namespace WebApiHotel.clases.apiProviders
{
    internal class HotelLegsApi : IHotelLegsApi
    {
        public string request(string json)
        {
            // Request to Hotellegs server
            Console.WriteLine("The request is sent with the data : -> {0}", json);
            // Set data to simulate response 
            HotelLegsResponseJson response1 = new HotelLegsResponseJson();
            response1.room = 1;
            response1.meal = 1;
            response1.canCancel = false;
            response1.price = 123.48;
            HotelLegsResponseJson response2 = new HotelLegsResponseJson();
            response2.room = 1;
            response2.meal = 1;
            response2.canCancel = true;
            response2.price = 150.00;
            HotelLegsResponseJson response3 = new HotelLegsResponseJson();
            response3.room = 2;
            response3.meal = 1;
            response3.canCancel = false;
            response3.price = 148.25;
            HotelLegsResponseJson response4 = new HotelLegsResponseJson();
            response4.room = 2;
            response4.meal = 2;
            response4.canCancel = false;
            response4.price = 165.38;

            List<HotelLegsResponseJson> resultsResponse = new List<HotelLegsResponseJson>();
            resultsResponse.Add(response1);
            resultsResponse.Add(response2);
            resultsResponse.Add(response3);
            resultsResponse.Add(response4);

            
            return JsonConvert.SerializeObject(resultsResponse);
        }
    }
}
