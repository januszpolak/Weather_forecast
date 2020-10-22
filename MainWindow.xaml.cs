using Newtonsoft.Json.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

                results = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=krakow&appid=085f4e9a1bb01af375c061ffa74b3886&units=metric");
            dynamic weatherResults = JObject.Parse(results);


            int temperature = weatherResults.main.temp;
            int pressure = weatherResults.main.pressure;
            double humidity = weatherResults.main.humidity;
            double visibility = weatherResults.visibility;
            string desc = weatherResults.weather[0].main;

            TextBlockTemp.Text = temperature.ToString() + "°C";
            TextBlockPressure.Text = "Ciśnienie: " + pressure.ToString() + " hPa";
            TextBlockHumidity.Text = "Wilgotność: " + humidity.ToString() + "%";
            TextBlockVisibility.Text = "Widoczność: " + visibility.ToString() + "m";



            if (desc == "Clouds")
            {
                Image.Source = new BitmapImage(new System.Uri("https://cdn.pixabay.com/photo/2017/02/07/01/59/cloud-2044797_960_720.png"));
            }

        }

      
    }
}
