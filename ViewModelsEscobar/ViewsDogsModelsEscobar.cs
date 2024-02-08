using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAPI.ViewModelsEscobar
{
    class ViewsDogsModelsEscobar
    {
        private Image dogsImage;

        public class Root
        {
            public string message { get; set; }
            public string status { get; set; }
        }

        public async void ViewDogsinScreen()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                using (var client = new HttpClient())
                {
                    string url = "https://dog.ceo/api/breeds/image/random";

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var root = JsonConvert.DeserializeObject<Root>(json);

                        dogsImage.Source = ImageSource.FromUri(new Uri(root.message));
                    }
                }
            }
        }
    }
}
