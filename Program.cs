using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace app
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string URL = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            IList<ApiResponse> collectionList = new List<ApiResponse>();

            HttpResponseMessage response = client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(data);
                //iterate over stats and print cellection name
                foreach (var item in json.stats)
                {
                    string n = item.collection.name;
                    string s = item.sales;
                    //check if floorPrice is not null
                    double f = 0;
                    double a = 0;
                    if (item.floorPrice != null)
                    {
                        f = (double)item.floorPrice;
                        a = (double)item.collection.stats.average_price;
                    }

                    string u = item.collection.external_url;
                    string d = item.collection.description;


                    collectionList.Add(new ApiResponse(n, s, f, a, u, d));

                }

                foreach (var item in collectionList)
                {
                    Console.WriteLine(item.name);
                 
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

        }
    }
}