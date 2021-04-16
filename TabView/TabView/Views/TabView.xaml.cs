using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.CreateAttached(
            nameof(Title),
            typeof(string),
            typeof(TabView),
            null);

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty IconImageSourceProperty = BindableProperty.CreateAttached(
            nameof(IconImageSource),
            typeof(ImageSource),
            typeof(TabView),
            null);

        public ImageSource IconImageSource
        {
            get => (ImageSource) GetValue(IconImageSourceProperty);
            set => SetValue(IconImageSourceProperty, value);
        }


        public TabView()
        {
            InitializeComponent();
        }
    }
}