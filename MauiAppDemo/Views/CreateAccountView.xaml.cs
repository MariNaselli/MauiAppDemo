using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views;

public partial class CreateAccountView : ContentPage
{
    public CreateAccountView(CreateAccountViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}