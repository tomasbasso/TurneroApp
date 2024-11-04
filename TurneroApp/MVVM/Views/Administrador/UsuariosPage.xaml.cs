using TurneroApp.MVVM.ViewModels.Administrador;
using Microsoft.Maui.Controls;

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