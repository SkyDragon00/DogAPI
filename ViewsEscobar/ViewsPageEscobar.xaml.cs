using Newtonsoft.Json;
using static DogAPI.ViewModelsEscobar.ViewsDogsModelsEscobar;

namespace DogAPI.ViewsEscobar
{
    public partial class ViewsPageEscobar : ContentPage
    {
        private Image doogsImage;

        public ViewsPageEscobar()
        {
            InitializeComponent();
            ViewDogsinScreen();
        }

        private async void ViewDogsinScreen()
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

        private void OtroperroButton_Clicked(object sender, EventArgs e)
        {
            ViewDogsinScreen();
        }

        private void GuardarButton_Clicked(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para guardar la imagen si lo deseas
        }

        public class Root
        {
            public string message { get; set; }
            public string status { get; set; }
        }
    }
}
