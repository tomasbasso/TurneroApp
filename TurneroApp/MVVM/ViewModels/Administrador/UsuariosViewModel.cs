using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using TurneroApp.MVVM.Models;
using TurneroApp.MVVM.Views.Administrador;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TurneroApp.MVVM.ViewModels.Administrador
{
    public partial class UsuariosViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<Usuario> Usuarios { get; } = new ObservableCollection<Usuario>();

        [ObservableProperty]
        Usuario usuarioSeleccionado;

        public ICommand CargarUsuariosCommand { get; }
        public ICommand EditarUsuariosCommand { get; }

        public UsuariosViewModel(ApiService apiService)
        {
            _apiService = apiService;
            CargarUsuariosCommand = new RelayCommand(async () => await OnCargarUsuarios());
        }

        private async Task OnCargarUsuarios()
        {
            try
            {
                var usuarios = await _apiService.ObtenerUsuario();
                Usuarios.Clear();
                Console.WriteLine($"Total de usuarios obtenidos: {usuarios.Count}"); // Para depuración
                foreach (var usuario in usuarios)
                {
                    Usuarios.Add(usuario);
                    Console.WriteLine($"Usuario: {usuario.Nombre}, Email: {usuario.Email}, Teléfono: {usuario.Telefono}"); // Para depuración
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        [RelayCommand]
        public async Task GoToUsuariosAgregar()
        {
            //await Application.Current.MainPage.Navigation.PushAsync(new UsuarioAgregarPage(new UsuarioAgregarViewModel(new ApiService())));
        }

        partial void OnUsuarioSeleccionadoChanged(Usuario value)
        {
            _ = GoToDetail(value);
        }

        private async Task GoToDetail(Usuario usuario)
        {
            //if (usuario != null)
            //{
            //    // Pasa el usuario seleccionado y el servicio al ViewModel de detalles
            //    var usuarioDetalleViewModel = new UsuarioDetalleViewModel(usuario, _apiService);
            //    var detallePage = new UsuarioDetallePage { BindingContext = usuarioDetalleViewModel };

            //    await Application.Current.MainPage.Navigation.PushAsync(detallePage);
            //}
        }
        //private async Task GoToDetail(Usuario usuario) NO ANDA
        //{
        //    if (usuario != null)
        //    {
        //        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioDetallePage());
        //    }
        //}

    }
}