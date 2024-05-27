using MauiAppDemo.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;


namespace MauiAppDemo.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private const string AuthTokenKey = "auth_token";

        public async Task LoginAsync(string user, string password)
        {
            bool isAuthenticated = await Task.FromResult(user == "admin" && password == "admin");

            if (isAuthenticated)
            {
                // Guardar el token (simulado)
                await SecureStorage.SetAsync(AuthTokenKey, "fake_token");
            }
            // Enviar el mensaje de autenticación
            WeakReferenceMessenger.Default.Send(new AuthenticationMessage(isAuthenticated));

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
