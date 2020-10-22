using Newtonsoft.Json.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace WeatherWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetWeather();
        }
        public void GetWeather()
        {
            string results;


            using (WebClient client = new WebClient())

                results = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=cracow&appid=085f4e9a1bb01af375c061ffa74b3886&units=metric");
            dynamic weatherResults = JObject.Parse(results);


            int temperature = weatherResults.main.temp;
            int pressure = weatherResults.main.pressure;
            double humidity = weatherResults.main.humidity;
            double visibility = weatherResults.visibility;
            string desc = weatherResults.weather[0].description;

            TextBoxTemp.Text = temperature.ToString() + "°C";
            TextBoxPressure.Text = "Ciśnienie: " + pressure.ToString() + " hPa";
            TextBoxHumidity.Text = "Wilgotność: " + humidity.ToString() + " %";
            TextBoxVisibility.Text = "Widoczność: " + visibility.ToString() + " m";
        }

      
    }
}
