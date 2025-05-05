using AppTempo.Models;
using Newtonsoft.Json.Linq;

public class DataService
{
	public static async Task<Tempo?> GetWeather(string city) // Not GetForecast() because it will get the realtime weather, and not a future data
	{
		Tempo? weather = null;

		string key = "Your OpenWeather api key";
		string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={key}";

		using (HttpClient httpClient = new HttpClient())
		{
			HttpResponseMessage response = await httpClient.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				string json = await response.Content.ReadAsStringAsync();

				JObject? draft = JObject.Parse(json);

				DateTime time = new DateTime();
				DateTime sunrise = time.AddSeconds(draft["sys"]!["sunrise"]!.ToObject<double>()).ToLocalTime();
				DateTime sunset = time.AddSeconds(draft["sys"]!["sunset"]!.ToObject<double>()).ToLocalTime();

				weather = new()
				{
					Latitude = draft["coord"]?["lat"]?.ToObject<double>(),
					Longitude = draft["coord"]?["lon"]?.ToObject<double>(),
					Visibility = draft["visibility"]?.ToObject<int>(),
					MaxTemperature = draft["main"]?["temp_max"]?.ToObject<double>(),
					MinTemperature = draft["main"]?["temp_min"]?.ToObject<double>(),
					Temperature = draft["main"]?["temp"]?.ToObject<double>(),
					Sunrise = sunrise.ToString(),
					Sunset = sunset.ToString(),
					Main = draft["weather"]?[0]?["main"]?.ToObject<string>(),
					Description = draft["weather"]?[0]?["description"]?.ToObject<string>(),
					WindSpeed = draft["wind"]?["speed"]?.ToObject<double>()
				}; 
			}  
		} 

		return weather;
	}
}
