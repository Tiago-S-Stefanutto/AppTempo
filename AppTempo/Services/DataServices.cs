using AppTempo.Models;
using Newtonsoft.Json.Linq;

namespace AppTempo.Services
{
    public class DataService
    {
        // Método para obter dados meteorológicos atuais por nome de cidade
        public static async Task<Tempo?> GetWeather(string city)
        {
            Tempo? weather = null;

            // Substitua pela sua chave de API OpenWeather
            string key = "Your OpenWeather api key";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={key}";

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    JObject? draft = JObject.Parse(json);

                    // Corrigindo a conversão de timestamp para DateTime
                    long sunriseTimestamp = draft["sys"]!["sunrise"]!.ToObject<long>();
                    long sunsetTimestamp = draft["sys"]!["sunset"]!.ToObject<long>();

                    // Usando DateTimeOffset para conversão correta de Unix timestamp
                    DateTime sunriseTime = DateTimeOffset.FromUnixTimeSeconds(sunriseTimestamp).LocalDateTime;
                    DateTime sunsetTime = DateTimeOffset.FromUnixTimeSeconds(sunsetTimestamp).LocalDateTime;

                    weather = new Tempo
                    {
                        Latitude = draft["coord"]?["lat"]?.ToObject<double>(),
                        Longitude = draft["coord"]?["lon"]?.ToObject<double>(),
                        Visibility = draft["visibility"]?.ToObject<int>(),
                        MaxTemperature = draft["main"]?["temp_max"]?.ToObject<double>(),
                        MinTemperature = draft["main"]?["temp_min"]?.ToObject<double>(),
                        Temperature = draft["main"]?["temp"]?.ToObject<double>(),
                        Sunrise = sunriseTime.ToString("HH:mm:ss"),
                        Sunset = sunsetTime.ToString("HH:mm:ss"),
                        Main = draft["weather"]?[0]?["main"]?.ToObject<string>(),
                        Description = draft["weather"]?[0]?["description"]?.ToObject<string>(),
                        WindSpeed = draft["wind"]?["speed"]?.ToObject<double>()
                    };
                }
            }

            return weather;
        }
    }
}