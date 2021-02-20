# IndoorClimateDesktop

The Desktop application is pre-alpha stage. The usable application will not have any elements that accept any for of user input.
Initially TCP listener will run continously in the background updating the UI when new data is received. This will change when the website part of the project is up and running, then the local data will be requested with a httpRequest call.
The forecast air quality data will be updated at set time intervals and updated on the GUI accordingly.

This is the Desktop application that will run on the RaspberryPi.
The idea is to use this as a smart mirror type display.
Alternatively the UI can be changed easily enough, that is the benifit of the MVVM design pattern.

To use the be able get the weatherForecast a openweathermap API key is needed.
This key can be added to a app.config file.
Add the file to the project and chnage the code to look like this:

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="OpenWeatherApiKey" value="replacethisstringwithyourapikey"/>
    <add key="ClimacelApiKey" value="replacethisstringwithyourapikey"/>
    <add key="ClimacelHomeLocationId" value="replacethisstringwithyourlocationID"/>
  </appSettings>
</configuration>
```

The project uses the following nuget packages:
Avalonia
Avalonia.Desktop
Avalonia.Diagnostics
Avalonia.ReactiveUI
System.Configuration.ConfgurationManager

There is a bug in the API call to climacel where the API sometimes return an empty JSON objects. This causes GetAirQualityAndPollenData(string apiKey, string locationId) to crash the application with an array overflow exception. This has temporarily been overcome by adding a try catch block at the async call. A better fix would be to check for empty array before trying to assign values.

In the near future I'll upload a sample JSON file containing sample local data that can be used to test out the application.
All that will be needed will be to swap this call:
```
string JsonString = await IndoorClimateTcpServer.Listen(13000);
```
with a call that reads the file into JsonString
