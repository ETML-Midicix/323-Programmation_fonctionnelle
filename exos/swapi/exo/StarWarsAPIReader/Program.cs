using System.Net.Http.Headers;
using System;
using System.Net;
using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Nodes;

namespace StarWarsAPIReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EX1("https://swapi.dev/api/films/");
        }

        static void EX1(string api)
        {
            System.Net.Http.HttpResponseMessage response = CallAPI(api);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                //Parse the response body

                //var dataObjects = response.Content
                //               .ReadAsAsync<IEnumerable<DataObject>>().Result;

                dynamic json = ConvertJSON(response.Content.ReadAsStringAsync().Result);

                //dynamic[] = JsonSerializer.Deserialize<dynamic[]>(json["results"]);

                Console.WriteLine(json["results"]);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                              response.ReasonPhrase);
            }
        }

        static dynamic ConvertJSON(string data)
        {
            return JsonConvert.DeserializeObject(data);
        }

        static System.Net.Http.HttpResponseMessage CallAPI(string api)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(api);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            // Get data response
            return client.GetAsync("").Result;
        }
    }
}
