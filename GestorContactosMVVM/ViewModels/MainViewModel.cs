

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorContactosMVVM.Models;
using GestorContactosMVVM.Services;
using GestorContactosMVVM.View;
using System.Collections.ObjectModel;
using Contact = GestorContactosMVVM.Models.Contact;

namespace GestorContactosMVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Contact> contactCollection = new ObservableCollection<Contact>();

        private readonly ContactsDataBase _service;

        public MainViewModel() {
            _service = new ContactsDataBase();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll() 
        {
            var getAll = _service.GetAll();

            if (getAll.Count > 0) {

                ContactCollection.Clear();
                foreach (var contact in getAll) {
                    ContactCollection.Add(contact);
                }
            }

          
        }

        [RelayCommand]
        private async Task GoToAddEditView() 
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }

        [RelayCommand]
        private async Task SelectContact(Contact Contact) {

            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);
                if (res == ACTUALIZAR)
                {
                    await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView(Contact));
                }
                else if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR Contacto", "¿Dese eliminar el Contacto?", "Si", "No");

                    if (respuesta)
                    {
                        int del = _service.Delete(Contact);

                        if (del > 0)
                        {
                            Alerta("ELIMINAR Contacto", "Empleado eliminado correctamente.");
                            ContactCollection.Remove(Contact);
                        }
                        else
                        {
                            Alerta("ELIMINAR Contacto", "No se eliminó el empleado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }   
    }
}
