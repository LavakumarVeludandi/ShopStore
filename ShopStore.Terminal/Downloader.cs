using System;
using Newtonsoft.Json;
using ShopStore.Terminal.Models;

namespace ShopStore.Terminal;

public static class Downloader
{
	public static async Task GetCategories(HttpClient client)
	{
		try
		{
			using (client)
			{
				HttpResponseMessage res = await client.GetAsync("api/Category/GetCategories");
				if(res.IsSuccessStatusCode)
				{
                    var catergories = JsonConvert.DeserializeObject<IEnumerable<Category>>(await res.Content.ReadAsStringAsync());
					if(catergories!=null){
                        foreach (var cat in catergories)
                            {
							Console.WriteLine(cat.CategoryId + " --- " + cat.CategoryName + " --- " + cat.Description);
                            }
                        }
                    }
			}
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex);
		}
	}

    internal static async Task GetDesktopWallpaper(HttpClient client)
    {
		try
		{
			using(client)
			{
                HttpResponseMessage res = await client.GetAsync("api/Image/GetDesktopWallpaper");
                if (res.IsSuccessStatusCode)
                {
					var image = await res.Content.ReadAsStreamAsync();
                }
            }
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex);
		}
    }
}

