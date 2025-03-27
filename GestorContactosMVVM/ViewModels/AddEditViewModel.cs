
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorContactosMVVM.Models;
using GestorContactosMVVM.Services;
using Contact = GestorContactosMVVM.Models.Contact;

namespace GestorContactosMVVM.ViewModels
{
    class AddEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string numeroTelefono;

        [ObservableProperty]
        private string correo;

        private readonly ContactsDataBase _service;

        public AddEditViewModel()
        {
            _service = new ContactsDataBase();
        }

        public AddEditViewModel(Contact Contact) {
            id = Contact.Id;
            nombre = Contact.Nombre;
            correo = Contact.Correo;
            numeroTelefono = Contact.NumeroTelefono;

        
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        { }
            
        
}
