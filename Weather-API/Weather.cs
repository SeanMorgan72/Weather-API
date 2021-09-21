using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Weather_API
{
    public class Weather
    {
        public static void ShowWeather()
        {
            var client = new HttpClient();

            Console.WriteLine("Please enter your API key: ");
            var api_key = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name: ");
                var cityName = Console.ReadLine();

                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={api_key}";

                var response = client.GetStringAsync(weatherURL).Result;

                var formatResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formatResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose another city to search: (y)es or (n)o?");
                var input = Console.ReadLine();

                if((input.ToLower() == "n") || (input.ToLower() == "no"))
                {
                    break;
                }
            }
        }
    }
}
