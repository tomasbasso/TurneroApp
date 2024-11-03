using TurneroApp.MVVM.ViewModels;
using TurneroApp.MVVM.Views;

namespace TurneroApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Instanciar el LoginViewModel y pasarlo a la LoginPage
            var loginViewModel = new LoginViewModel();

            MainPage = new NavigationPage(new LoginPage(loginViewModel));
        }
    }
}
