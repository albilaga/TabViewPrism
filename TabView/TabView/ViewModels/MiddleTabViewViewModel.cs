using System.Windows.Input;
using Prism.Commands;
using Prism.Services;

namespace TabView.ViewModels
{
    public class MiddleTabViewViewModel : BaseViewModel
    {
        private readonly IPageDialogService _pageDialogService;
        private ICommand _tapCommand;

        public ICommand TapCommand => _tapCommand ??= new DelegateCommand(async () =>
        {
            await _pageDialogService.DisplayAlertAsync("Info", "Middle Tab Tapped", "OK");
        });

        public MiddleTabViewViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
        }
    }
}