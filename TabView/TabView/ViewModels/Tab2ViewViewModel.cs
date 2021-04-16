using System;

namespace TabView.ViewModels
{
    public class Tab2ViewViewModel : BaseViewModel
    {
        public string Title => "Hello Tab 2";

        public Tab2ViewViewModel()
        {
            
        }
        protected override void OnTabViewActivated()
        {
            base.OnTabViewActivated();
            Console.WriteLine("Tab 2 activated");
        }

        protected override void OnTabViewDeactivated()
        {
            base.OnTabViewDeactivated();
            Console.WriteLine("Tab 2 Deactivated");
        }
    }
}