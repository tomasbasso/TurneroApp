using TurneroApp.MVVM.ViewModels.Administrador;


namespace TurneroApp.MVVM.Views.Administrador 
{

    public partial class UsuariosPage : ContentPage
    {
        public UsuariosPage(UsuariosViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}