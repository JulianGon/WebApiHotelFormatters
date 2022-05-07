using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiHotel.clases.apiProviders;
using WebApiHotel.clases.formatters;
using WebApiHotel.clases.json.hub;
using WebApiHotel.clases.json.providers;
using WebApiHotel.interfaces.apis;

namespace WebApiHotel.clases.formatters
{
    /// <summary>
    /// Concrete adapter for HotelLegs
    /// </summary>
    public class HubFormattHotellegs : HubFormatt
    {
        private HotelLegsApi apiHotellegs;

        /// <summary>
        /// Load appropriate API
        /// </summary>
        /// <param name="apiProvider">HotelLegsApi</param>
        public HubFormattHotellegs(IProvidersApi apiProvider) : base(apiProvider)
        {
            apiHotellegs = (HotelLegsApi) apiProvider;
        }

        /// <summary>
        /// Format hubjson Request in HotelLegs Request and call api.request()
        /// </summary>
        /// <param name="json">Hub Json</param>
        /// <returns>HotelTravel Json</returns>
        /// <exception cref="JsonException"></exception>
        public override string formatReqAndRequest(HubFormatRequest hubJson)
        {
            //HubRequestJson? hubJson = JsonConvert.DeserializeObject<HubRequestJson>(json);
            HotelLegsRequestJson hotellegsJson = new HotelLegsRequestJson();
            if(hubJson != null)
            {
                hotellegsJson.hotel = hubJson.hotelId;
                hotellegsJson.currency = hubJson.currency;
                hotellegsJson.rooms = hubJson.numbetOfRooms;
                hotellegsJson.guests = hubJson.numberOfGuests;
                hotellegsJson.checkInDate = hubJson.checkIn;
                string[] checkIn = hubJson.checkIn.Split('-');
                string[] checkOut = hubJson.checkOut.Split('-');
                DateTime checkInDate = new DateTime(int.Parse( checkIn[0]), int.Parse(checkIn[1]), int.Parse(checkIn[2]));
                DateTime checkOutDate = new DateTime(int.Parse(checkOut[0]), int.Parse(checkOut[1]), int.Parse(checkOut[2]));
                TimeSpan difDates =  checkOutDate - checkInDate;
                int dayStay = difDates.Days;
                hotellegsJson.numberOfNights = dayStay.ToString();

                return apiHotellegs.request(JsonConvert.SerializeObject(hotellegsJson)); 
            }
            else
            {
                throw new JsonException($"Error occurs during JSON serialization or deserialization or empty Request. Received JSON {apiHotellegs.GetType().ToString()}");
            }
        }

        /// <summary>
        /// Format HotelLegs Response in hubjson Response and return the response
        /// </summary>
        /// <param name="json">HotelLegs Response</param>
        /// <returns>hubjson Response</returns>
        /// <exception cref="JsonException"></exception>
        public override string formatRes(string json)
        {
            List<HotelLegsResponseJson>? hotellegsJson = JsonConvert.DeserializeObject<List<HotelLegsResponseJson>>(json);
            List< HubRoomResponseJson > rooms = new List<HubRoomResponseJson >();
            if (hotellegsJson != null) {
                foreach (HotelLegsResponseJson jsonHotellegResponse in hotellegsJson)
                {
                    HubRateResponseJson rate = new HubRateResponseJson();
                    rate.price = jsonHotellegResponse.price;
                    rate.mealPlanId = jsonHotellegResponse.meal;
                    rate.isCancellable = jsonHotellegResponse.canCancel;
                
                    HubRoomResponseJson room = new HubRoomResponseJson();
                    room.roomId = jsonHotellegResponse.room;
                    room.rates = new List<HubRateResponseJson>();
                    room.rates.Add(rate);
                    if (rooms.Count == 0)
                    {
                        rooms.Add(room);
                    }
                    else 
                    {
                        if (rooms.Last().roomId == room.roomId)
                        {
                            rooms.Last().rates.Add(rate);
                        }
                        else 
                        {
                            rooms.Add(room);
                        }    
                    }
                }
                return JsonConvert.SerializeObject(rooms);
            }
            else
            {
                throw new JsonException($"Error occurs during JSON serialization or deserialization or empty Response. Received JSON {json}");
            }
        }
    }
}
