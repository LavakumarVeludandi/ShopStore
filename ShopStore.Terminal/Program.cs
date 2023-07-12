using ShopStore.Terminal;


var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) =>{ return true; };

HttpClient client = new HttpClient(handler);
client.BaseAddress = new Uri("http://localhost:5180/");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/octet-stream"));
Downloader.GetCategories(client).Wait();
Downloader.GetDesktopWallpaper(client).Wait();