

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
    }
}
