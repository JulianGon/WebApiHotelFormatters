namespace WebApiHotel.interfaces.apis
{

        /// <summary>
        /// Interface for diferent API providers
        /// </summary>
        public interface IProvidersApi
        {
            public string request(string hubJson);
        }

        internal interface IHotelLegsApi : IProvidersApi { };
        internal interface ITravelDoorsXApi : IProvidersApi { };
        internal interface ISpeediaApi : IProvidersApi { };
    
}
