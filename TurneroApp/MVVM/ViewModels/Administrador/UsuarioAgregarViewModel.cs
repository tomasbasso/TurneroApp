    using System.Collections.ObjectModel;
    using CommunityToolkit.Mvvm.Input;
    using TurneroApp.MVVM.Models;
    using CommunityToolkit.Mvvm.ComponentModel;
    using Microsoft.Win32;
    using TurneroApp.MVVM.Models.ModelsDTO;

namespace TurneroApp.MVVM.ViewModels.Administrador
{
        public partial class UsuarioAgregarViewModel : BaseViewModel
        {
            private readonly ApiService _apiService;
            public ObservableCollection<CrearUsuarioDTO> Usuarioscrear { get; set; } = new ObservableCollection<CrearUsuarioDTO>();
            public ObservableCollection<Usuario> Usuarios { get; set; } = new ObservableCollection<Usuario>();

            [ObservableProperty] private string nombre;
            [ObservableProperty] private string email;
            [ObservableProperty] private string telefono;
            [ObservableProperty] private int idrol;
            [ObservableProperty] private string contraseña;

            public UsuarioAgregarViewModel(ApiService apiService)
            {
                _apiService = apiService;
              
            }

            [RelayCommand]
            private async Task CancelarUsuario()
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            [RelayCommand]
            private async Task GrabarUsuario()
            {
            var _usuario = new CrearUsuarioDTO
            {
                Nombre = this.nombre,
                Email = this.email,
                Contraseña = this.contraseña,
                Telefono = this.telefono,
                IdRol = this.idrol
            };

                try
                {
                    await ApiService.AgregarUsuario(_usuario);

                    await Application.Current.MainPage.DisplayAlert("Exito", "Se un nuevo Producto.", "Aceptar");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "ERROR al grabar.", "Aceptar");
                }

                await Application.Current.MainPage.Navigation.PopAsync();


            }
        }
    }