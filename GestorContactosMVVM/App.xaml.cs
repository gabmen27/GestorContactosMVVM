using GestorContactosMVVM.View;

namespace GestorContactosMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
        }
    }
}
