

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

        [ObservableProperty]
        private string searchText;

        private List<Contact> _allContacts;

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
            _allContacts = _service.GetAll();


            FilterContacts();


        }

        private void FilterContacts()
        {
            if (_allContacts == null) return;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                ContactCollection.Clear();
                foreach (var contact in _allContacts)
                {
                    ContactCollection.Add(contact);
                }
            }
            else
            {
    
                var filteredContacts = _allContacts
                    .Where(c => !string.IsNullOrEmpty(c.Nombre) &&
                                c.Nombre.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                ContactCollection.Clear();
                foreach (var contact in filteredContacts)
                {
                    ContactCollection.Add(contact);
                }
            }
        }

      
        partial void OnSearchTextChanged(string value)
        {
            FilterContacts();
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
                            Alerta("ELIMINAR Contacto", "Contacto eliminado correctamente.");
                            ContactCollection.Remove(Contact);
                        }
                        else
                        {
                            Alerta("ELIMINAR Contacto", "No se eliminó el Contacto");
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
