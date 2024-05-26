using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;

namespace MauiAppDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            //Comentamos lo siguiente ya que se usa para la definicion
            //de rutas adcionales como /perros/detalles
            //Ver documentacion: Registro de rutas de la página de detalles

            //Routing.RegisterRoute(nameof(CreateAccountView), typeof(CreateAccountView));
            //Routing.RegisterRoute(nameof(HomePageView), typeof(HomePageView));

        }
    }
}
