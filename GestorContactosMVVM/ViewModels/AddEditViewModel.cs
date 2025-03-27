
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorContactosMVVM.Models;
using GestorContactosMVVM.Services;
using Contact = GestorContactosMVVM.Models.Contact;

namespace GestorContactosMVVM.ViewModels
{
    partial class AddEditViewModel : ObservableObject
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
            Id = Contact.Id;
            Nombre = Contact.Nombre;
            Correo = Contact.Correo;
            NumeroTelefono = Contact.NumeroTelefono;

        
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]

        private async Task AddUpdate()
        {
            try
            {

                Contact Contact = new Contact
                {
                    Id = Id,
                    Nombre = Nombre,
                   NumeroTelefono = NumeroTelefono,
                    Correo = Correo,
                };

                if (Contact.Nombre is null || Contact.Nombre == "")
                {
                    Alerta("ADVERTENCIA", "Ingrese el nombre completo");
                }
                else
                {
                    if (Id == 0)
                    {
                        _service.Insert(Contact);
                    }
                    else
                    {
                        _service.Update(Contact);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        internal void GetAll()
        {
            throw new NotImplementedException();
        }
    }
            
        
}
