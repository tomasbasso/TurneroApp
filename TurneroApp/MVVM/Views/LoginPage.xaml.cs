using TurneroApp.MVVM.ViewModels;

namespace TurneroApp.MVVM.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}