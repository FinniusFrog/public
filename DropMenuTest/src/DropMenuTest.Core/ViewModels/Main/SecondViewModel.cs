using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace DropMenuTest.Core.ViewModels.Main
{
    public class SecondViewModel : BaseViewModel
    {
        public IMvxAsyncCommand OpenMainViewModel { get; }

        private readonly IMvxNavigationService _navigationService;

        public SecondViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            OpenMainViewModel = new MvxAsyncCommand(OnOpenMainViewModelAsync);
        }

        private async Task OnOpenMainViewModelAsync()
        {
            await _navigationService.Navigate<MainViewModel>();
        }
    }
}
