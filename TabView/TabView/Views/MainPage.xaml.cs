using System;
using System.Linq;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace TabView.Views
{
    public partial class MainPage : INavigationAware
    {
        private int _oldPosition;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (TabView.TabItems.Any() &&
                TabView.TabItems[_oldPosition].Content?.BindingContext is IActiveAware activeAware)
            {
                activeAware.IsActive = true;
            }
        }

        private void TabView_OnSelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            // Can not rely on e.old position
            if (TabView.TabItems[_oldPosition].Content.BindingContext is IActiveAware oldTabAware)
            {
                oldTabAware.IsActive = false;
            }

            if (TabView.TabItems[e.NewPosition].Content.BindingContext is IActiveAware newTabAware)
            {
                newTabAware.IsActive = true;
            }

            _oldPosition = e.NewPosition;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters.Count == 0)
                {
                    return;
                }

                var tabs = parameters.GetValues<string>(KnownNavigationParameters.CreateTab);
                foreach (var tab in tabs)
                {
                    var view = App.Current.Container.Resolve(typeof(object), tab) as ContentView;
                    if (view is null)
                    {
                        continue;
                    }

                    if (App.Current.Container.Resolve(typeof(BindableBase),
                        $"{tab}ViewModel") is BindableBase viewModel)
                    {
                        view.BindingContext = viewModel;
                    }

                    TabView.TabItems.Add(new TabViewItem
                    {
                        Text = tab,
                        Content = view
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}