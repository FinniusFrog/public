using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace DropMenuTest.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public IMvxAsyncCommand OpenSecondViewModel { get; }

        private readonly IMvxNavigationService _navigationService;


        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            OpenSecondViewModel = new MvxAsyncCommand(OnOpenSecondViewModelAsync);
        }

        private async Task OnOpenSecondViewModelAsync()
        {
            await _navigationService.Navigate<SecondViewModel>();
        }
    }
}
