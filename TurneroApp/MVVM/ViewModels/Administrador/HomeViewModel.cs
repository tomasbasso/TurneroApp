using TurneroApp.MVVM.Models;
using TurneroApp.MVVM.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using TurneroApp.MVVM.Views.Administrador;

namespace TurneroApp.MVVM.ViewModels.Administrador
{
    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string nombre = Transport.Nombre;

        // Comandos para la navegación
        [RelayCommand]
        public async Task GoToHomePage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HomePage(this));  // Navega a HomePage
        }

        [RelayCommand]
        public async Task GoToUsuariosPage()
        {
            await Application.Current.MainPage.DisplayAlert("Atención", "usuarios", "Aceptar");  // Navega a UsuariosPage
        }

        [RelayCommand]
        public async Task GoToCarritoPage()
        {

            await Application.Current.MainPage.DisplayAlert("Atención", "carrito", "Aceptar");
        }

        [RelayCommand]
        public async Task GoToPedidosPage()
        {
            await Application.Current.MainPage.DisplayAlert("Atención", "pedido", "Aceptar");
        }
    }
}