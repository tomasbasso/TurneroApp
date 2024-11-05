using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using TurneroApp.MVVM.Models;
using TurneroApp.MVVM.Views.Administrador;
using CommunityToolkit.Mvvm.ComponentModel;
using TurneroApp.MVVM.Models.ModelsDTO;

namespace TurneroApp.MVVM.ViewModels.Administrador
{
    public partial class ServiciosViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<VerServiciosDTO> Servicios { get; set; }

        public ICommand CargarServiciosCommand { get; }

        public ServiciosViewModel()
        {
            _apiService = new ApiService();
            Servicios = new ObservableCollection<VerServiciosDTO>();
            CargarServiciosCommand = new Command(async () => await CargarServicios());
        }
        private async Task CargarServicios()
        {
            try
            {
                var servicios = await _apiService.ObtenerServiciosAsync();
                Servicios.Clear();
                foreach (var servicio in servicios)
                {
                    Servicios.Add(servicio);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores (por ejemplo, mostrar un mensaje de error en la UI)
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task GoToProductoAgregar()
        {
            //   await Application.Current.MainPage.Navigation.PushAsync(new ProductoAgregarPage(new ProductoAgregarViewModel(new ApiService())));
        }

        //partial void OnServicioSeleccionadoChanged(Servicio value)
        //{
        //    _ = GoToDetail(value);
        //}

        private async Task GoToDetail(Servicio servicio)
        {
            //if (producto != null)
            //{
            //    var productoDetalleViewModel = new ProductoDetalleViewModel(producto, _apiService);
            //    var detallePage = new ProductoDetallePage { BindingContext = productoDetalleViewModel };

            //    await Application.Current.MainPage.Navigation.PushAsync(detallePage);
            //}
        }
    }
}
