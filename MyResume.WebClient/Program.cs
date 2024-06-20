using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using MyResume.WebClient.Application.Contracts;
using MyResume.WebClient.Application.Services;
using MyResume.WebClient.Helpers;

namespace MyResume.WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp =>
                new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddScoped<IJobSeekerService, JobSeekerService>();
            builder.Services.AddScoped<IVacancyService, VacancyService>();
            builder.Services.AddScoped<IEmployerService, EmployerService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IBranchService, BranchService>();

            builder.Services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthorizeApi>();
            builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

            builder.Services.AddFluentUIComponents();

            await builder.Build().RunAsync();
        }
    }
}
