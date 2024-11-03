using TurneroApp.MVVM.Models;
using TurneroApp.MVVM.ViewModels;
using TurneroApp.MVVM.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TurneroApp.MVVM.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string title = string.Empty;


}