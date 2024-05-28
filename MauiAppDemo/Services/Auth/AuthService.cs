using MauiAppDemo.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;
using System.Net.Http.Json;
using MauiAppDemo.Services.Auth;


namespace MauiAppDemo.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private const string AuthTokenKey = "";

        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoginAsync(string username, string password)
        {
            var loginRequest = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("/api/users/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (result != null && !string.IsNullOrEmpty(result.Token))
                {
                    // Guardar el token
                    await SecureStorage.SetAsync(AuthTokenKey, result.Token);
                    // Enviar el mensaje de autenticación
                    WeakReferenceMessenger.Default.Send(new AuthenticationMessage(true));
                }
                else
                {
                    // Enviar el mensaje de autenticación fallida
                    WeakReferenceMessenger.Default.Send(new AuthenticationMessage(false));
                }
            }
            else
            {
                // Enviar el mensaje de autenticación fallida
                WeakReferenceMessenger.Default.Send(new AuthenticationMessage(false));
            }
        }


        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await SecureStorage.GetAsync(AuthTokenKey);
            return !string.IsNullOrEmpty(token);
        }

        public async Task LogoutAsync()
        {
            // Remover el token
            SecureStorage.Remove(AuthTokenKey);

            // Enviar el mensaje de logout
            WeakReferenceMessenger.Default.Send(new AuthenticationMessage(false));

            // Simular una operación asíncrona para ilustrar el uso de await
            await Task.Delay(1);
        }
    }
}
