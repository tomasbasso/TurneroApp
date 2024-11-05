using TurneroApp.MVVM.ViewModels.Administrador;


namespace TurneroApp.MVVM.Views.Administrador
{

    public partial class ServiciosPage : ContentPage
    {
        public ServiciosPage(ServiciosViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}