﻿

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorContactosMVVM.View;

namespace GestorContactosMVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task GoToAddEditView() 
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }
    }
}
