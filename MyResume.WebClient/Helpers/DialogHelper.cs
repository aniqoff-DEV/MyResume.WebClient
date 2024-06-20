using Microsoft.FluentUI.AspNetCore.Components;
using MyResume.WebClient.Application.Responses.BranchResponses;
using MyResume.WebClient.Application.Responses.LocationResponses;
using MyResume.WebClient.Dialogs;

namespace MyResume.WebClient.Helpers
{
    public class DialogHelper
    {
        public static async Task<CityResponse> OpenCityDialog(CityResponse city, IDialogService dialogService)
        {
            var dialog = await dialogService.ShowDialogAsync<CityDialog>(city, new DialogParameters()
            {
                Height = "350px",
                Title = $"Ваши города",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            });

            var result = await dialog.Result;
            if (!result.Cancelled && result.Data != null)
            {
                return (CityResponse)result.Data;
            }
            return city;
        }

        public static async Task<BranchResponse> OpenBranchDialog(BranchResponse branch, IDialogService dialogService)
        {
            var dialog = await dialogService.ShowDialogAsync<BranchDialog>(branch, new DialogParameters()
            {
                Height = "350px",
                Title = $"Специальности",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            });

            var result = await dialog.Result;
            if (!result.Cancelled && result.Data != null)
            {
                return (BranchResponse)result.Data;
            }
            return branch;
        }

        public static async Task OpenLoginDialog(IDialogService dialogService)
        {
            var dialog = await dialogService.ShowDialogAsync<LoginDialog>(new DialogParameters()
            {
                Title = "Войти",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
                PrimaryAction = "Остаться",
                SecondaryAction = "Уйти"
            });
        }
    }
}
