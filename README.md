# IndoorClimateDesktop

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
  </appSettings>
</configuration>
```

The project uses the following nuget packages:
Avalonia
Avalonia.Desktop
Avalonia.Diagnostics
Avalonia.ReactiveUI
System.Configuration.ConfgurationManager
