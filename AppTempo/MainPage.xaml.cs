using AppTempo.Models;
using AppTempo.Services;

namespace AppTempo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void searchButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cityEntry.Text))
                {
                    Tempo? weather = await DataService.GetWeather(cityEntry.Text);

                    if (weather != null)
                    {
                        string weatherData = $"Latitude: {weather.Latitude}\n" +
                                      $"Longitude: {weather.Longitude}\n" +
                                      $"Temperatura: {weather.Temperature}°C\n" +
                                      $"Temperatura Máxima: {weather.MaxTemperature}°C\n" +
                                      $"Temperatura Mínima: {weather.MinTemperature}°C\n" +
                                      $"Principal: {weather.Main}\n" +
                                      $"Descrição: {weather.Description}\n" +
                                      $"Nascer do Sol: {weather.Sunrise}\n" +
                                      $"Pôr do Sol: {weather.Sunset}\n" +
                                      $"Visibilidade: {weather.Visibility} m\n" +
                                      $"Velocidade do Vento: {weather.WindSpeed} m/s\n";

                        responseLabel.Text = weatherData;
                    }
                    else
                    {
                        responseLabel.Text = "Não foram encontrados dados meteorológicos.";
                    }
                }
                else
                {
                    responseLabel.Text = "Por favor, digite o nome de uma cidade.";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}