using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TurneroApp.MVVM.Views;
using TurneroApp.MVVM.ViewModels;
using TurneroApp.MVVM.ViewModels.Administrador;
using TurneroApp.MVVM.Views.Administrador;

namespace TurneroApp.MVVM.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty] private string email = string.Empty;
        [ObservableProperty] private string contraseña = string.Empty;
        [ObservableProperty] private string message = string.Empty;

        [RelayCommand]
        public async Task LoginAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(contraseña))
                {
                    var apiClient = new ApiService();

                    try
                    {
                        var login = await apiClient.ValidarLogin(email, contraseña);

                        if (login != null && login.IdUsuario != 0)
                        {
                            
                            Transport.IdUsuario = login.IdUsuario;
                            Transport.Nombre = login.Nombre;
                            Transport.Email = login.Email;
                            Transport.IdRol = login.IdRol;

                     
                            if (login.IdRol == 3) //cliente
                            {
                                await Application.Current.MainPage.DisplayAlert("Atención", "cliente", "Aceptar");

                            }
                            else 
                            {
                                await Application.Current.MainPage.DisplayAlert("Atención", "admin", "Aceptar");
                                await Application.Current.MainPage.Navigation.PushAsync(new HomePage(new HomeViewModel()));
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Atención", "Credenciales Incorrectas", "Aceptar");
                        }
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Atención", "Error", "Aceptar");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Atención", "Las credenciales son obligatorias. Verifique!", "Aceptar");
                  
                }

                IsBusy = false;
            }
        }
    }
}