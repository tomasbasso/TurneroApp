﻿using TurneroApp.MVVM.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

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

                        if (login != null && login.usuario_id != 0)
                        {
                            Transport.usuario_id = login.usuario_id;
                            Transport.nombre = login.nombre;
                            Transport.email = login.email;

                            await Application.Current.MainPage.DisplayAlert("Atención", "Inicio de sesión exitoso", "Aceptar");


                            //await Application.Current.MainPage.Navigation.PushAsync(new HomePage(new HomeViewModel()));
                        }
                        else
                        {
                            Message = "Credenciales incorrectas. Intente nuevamente.";
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = $"Error: {ex.Message}";
                    }
                }
                else
                {
                    Message = "Las credenciales son obligatorias. Verifique!";
                }

                IsBusy = false;
            }
        }
    }
}