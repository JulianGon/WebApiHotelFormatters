# WebApiHotelFormatters
Pruebas con ASP.NET
# Moonhotels' HUB

En este proyecto se puede encontrar la clase central Hub cuyo único métedo "search" recibe una Request en formato Hub.
```json
{
    "hotelId": 1,
    "checkIn": "2018-10-20",
    "checkOut": "2018-10-25",
    "numberOfGuests": 3,
    "numberOfRooms": 2,
    "currency": "EUR"
}
```
y devuelve una única Response con el formato común (Formato Hub) con todas las Response obtenidas de los distintos proveedores
Response:
```json
{
    "rooms": [
        {
            "roomId": 1,
            "rates": [
                {
                    "mealPlanId": 1,
                    "isCancellable": false,
                    "price": 123.48
                },
                {
                    "mealPlanId": 1,
                    "isCancellable": true,
                    "price": 150.00
                }
            ]
        },
        {
            "roomId": 2,
            "rates": [
                {
                    "mealPlanId": 1,
                    "isCancellable": false,
                    "price": 148.25
                },
                {
                    "mealPlanId": 2,
                    "isCancellable": false,
                    "price": 165.38
                }
            ]
        }
    ]
}
```
Esta clase hace uso del objeto adapter, cuya clase varía en función de la Api del proveedor específico con el fin de encapsular el formateo correcto del json para cada proveedor. Esta clase 
también ejecuta la llamada request() a la API específica ya que encapsula la clase correspondiente a la API del proveedor. Todas las clases del adapter heredan de la clase abstracta "HubFormatt" 
que integra la interface IHubFormat. Todas las clases de las API integran IProvidersAPI mediante interfaces específicas. 