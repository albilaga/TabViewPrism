using Prism.Ioc;
using Prism.Mvvm;

namespace TabView
{
    public static class IContainerRegistryExtensions
    {
        public static void RegisterTabbedView<TView, TViewModel>(this IContainerRegistry containerRegistry)
            where TView : Views.TabView
            where TViewModel : BindableBase
        {
            var viewType = typeof(TView);
            containerRegistry.Register(typeof(object), viewType, viewType.Name);
            var viewModelType = typeof(TViewModel);
            containerRegistry.Register(typeof(BindableBase), viewModelType, viewModelType.Name);
        }
    }
}