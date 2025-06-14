using DekhaRealEstate.Client.services.HouseServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DekhaRealEstate.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });

        builder.Services.AddScoped<IHouseServices, HouseServices>();

        await builder.Build().RunAsync();
    }
}
