using TurneroApp.MVVM.ViewModels.Administrador;

namespace TurneroApp.MVVM.Views.Administrador;

public partial class UsuariosAgregarPage : ContentPage
{
    public UsuariosAgregarPage(UsuarioAgregarViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}