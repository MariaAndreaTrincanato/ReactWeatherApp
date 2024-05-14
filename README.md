# WeatherApp

This is an example of a web application with a frontend developed in React and a backend developed in .NET 8.

*You need to create a https://openweathermap.org/ user with a new token to use this app. The token must replace the one you can find in the appSettings.json file.*

#### Client
In the client you are able to search for a city to get the current weather. You can also save the searched city as a favorite to always have it below the search field.

#### Backend
This is a clean architecture REST API that serves the weather for the current city after parsing the result from the openweather API request. It also has the complete implementation of the endpoint to get the five day forecast for the searched city. The client does not have the complete implementation to show the result but you can use Swagger or a tool like Postman to see the result.
