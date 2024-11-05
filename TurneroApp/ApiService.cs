using TurneroApp.MVVM.Models;
using System.Text.Json;
using System.Text;
using TurneroApp.MVVM.Models.ModelsDTO;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json.Serialization;
using System.Net.Http;



namespace TurneroApp
{
    public class ApiService
    {
        private static readonly string BASE_URL = "http://localhost:5103/api/";
        static HttpClient httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };


        public async Task<LoginResponseDto> ValidarLogin(string _email, string _contraseña)
        {
            string FINAL_URL = BASE_URL + "Usuario/ValidarCredencial";
            try
            {
                var content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        Email = _email,
                        Contraseña = _contraseña,
                    }),
                    Encoding.UTF8, "application/json"
                );

                var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);
                var jsonData = await result.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    var responseObject = JsonSerializer.Deserialize<LoginResponseDto>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });


                    if (responseObject.IdUsuario == 0)
                    {
                        throw new Exception("Credenciales incorrectas");
                    }

                    return responseObject;
                }
                else
                {
                    throw new Exception("Resource Not Found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Método para obtener todos los usuarios
        public async Task<List<VerUsuariosDTO>> ObtenerUsuariosAsync()
        {
            string FINAL_URL = BASE_URL + "Usuario";
            try
            {
                var response = await httpClient.GetAsync(FINAL_URL).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var usuarios = JsonSerializer.Deserialize<List<VerUsuariosDTO>>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });

                    return usuarios;
                }
                else
                {
                    throw new Exception("Error al obtener los usuarios.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error de red: {ex.Message}");
            }

        }
        public static async Task<bool> AgregarUsuario(CrearUsuarioDTO _usuario)
        {
            string FINAL_URL = BASE_URL + "Usuario/CrearUsuario";
            try
            {


                var content = new StringContent(
                    JsonSerializer.Serialize(_usuario),
                    Encoding.UTF8, "application/json"

                );

                var result = await httpClient.PostAsync(FINAL_URL, content).ConfigureAwait(false);

                if (result.IsSuccessStatusCode)
                {

                    return true;
                }


                var errorResponse = await result.Content.ReadAsStringAsync();
                throw new Exception($"Error al agregar usuario: {errorResponse}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<VerServiciosDTO>> ObtenerServiciosAsync()
        {
            string FINAL_URL = BASE_URL + "Servicio/ObtenerServicios";
            try
            {
                var response = await httpClient.GetAsync(FINAL_URL).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var servicios = JsonSerializer.Deserialize<List<VerServiciosDTO>>(jsonData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        });

                    return servicios;
                }
                else
                {
                    throw new Exception("Error al obtener los servicios.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error de red: {ex.Message}");
            }
        }
    }




}