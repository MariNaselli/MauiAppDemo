
namespace MauiAppDemo.Messages
{
    public class NavigateTo
    {
        public string Route { get; }

        public NavigateTo(string route)
        {
            Route = "//" + route;
        }
    }
}
