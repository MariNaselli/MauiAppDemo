using System.Diagnostics;

namespace MauiAppDemo.Views;

public partial class AuthShell : Shell
{
	public AuthShell()
	{
		InitializeComponent();
        Debug.WriteLine("AuthShell initialized");
    }
}