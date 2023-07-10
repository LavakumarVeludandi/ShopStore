using ShopStore.Terminal;


var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) =>{ return true; };

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5180/");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
Downloader.GetCategories(client).Wait();