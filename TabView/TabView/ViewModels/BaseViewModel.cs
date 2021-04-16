using System;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;

namespace TabView.ViewModels
{
    public class BaseViewModel : BindableBase, IActiveAware,INavigationAware
    {
        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, () => IsActiveChanged?.Invoke(this, null));
        }

        public event EventHandler IsActiveChanged;

        public BaseViewModel()
        {
            IsActiveChanged += OnIsActiveChanged;
        }

        ~BaseViewModel()
        {
            IsActiveChanged -= OnIsActiveChanged;
        }
        
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        protected virtual void OnTabViewActivated()
        {
        }

        protected virtual void OnTabViewDeactivated()
        {
        }


        private void OnIsActiveChanged(object sender, EventArgs e)
        {
            if (IsActive)
            {
                OnTabViewActivated();
            }
            else
            {
                OnTabViewDeactivated();
            }
        }
    }
}