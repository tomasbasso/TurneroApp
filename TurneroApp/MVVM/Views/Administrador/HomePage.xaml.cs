using TurneroApp.MVVM.ViewModels.Administrador;

namespace TurneroApp.MVVM.Views.Administrador;

public partial class HomePage : ContentPage
{

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}