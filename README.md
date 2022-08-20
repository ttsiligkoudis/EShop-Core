# EShop-Core

This is the second version of the EShop project with **ASP.NET Core**.<br>
It has all the main features described in the previous EShop MVC project but it was build with a more advanced approach.<br>
It features **Repository Pattern** in order to build a loosely-coupled web application.<br>
Only the API Controller is connected to the Repository.<br>
The MVC Controller receives data through requests that are made through a custom **Http-Client** with polymorphic behaviour.<br>
Lastly the project has embedded a complete **API Documentation** using **Swagger**.
