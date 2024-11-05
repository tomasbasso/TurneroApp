using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using TurneroApp.MVVM.Models;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using TurneroApp.MVVM.Models.ModelsDTO;
using TurneroApp.MVVM.Views.Administrador;

namespace TurneroApp.MVVM.ViewModels.Administrador
{
    public partial class UsuariosViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<VerUsuariosDTO> Usuarios { get; set; }

        public ICommand CargarUsuariosCommand { get; }

        public UsuariosViewModel()
        {
            _apiService = new ApiService();
            Usuarios = new ObservableCollection<VerUsuariosDTO>();
            CargarUsuariosCommand = new Command(async () => await CargarUsuarios());
        }

        private async Task CargarUsuarios()
        {
            try
            {
                var usuarios = await _apiService.ObtenerUsuariosAsync();
                Usuarios.Clear();
                foreach (var usuario in usuarios)
                {
                    Usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores (por ejemplo, mostrar un mensaje de error en la UI)
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        [RelayCommand]
        public async Task GoToUsuariosAgregar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuariosAgregarPage(new UsuarioAgregarViewModel(new ApiService())));
        }
    }
}
