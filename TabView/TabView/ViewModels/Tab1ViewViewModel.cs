using System;

namespace TabView.ViewModels
{
    public class Tab1ViewViewModel : BaseViewModel
    {
        public string Title => "Hello Tab 1";

        public Tab1ViewViewModel()
        {
            
        }

        protected override void OnTabViewActivated()
        {
            base.OnTabViewActivated();
            Console.WriteLine("Tab 1 activated");
        }

        protected override void OnTabViewDeactivated()
        {
            base.OnTabViewDeactivated();
            Console.WriteLine("Tab 1 Deactivated");
        }
    }
}