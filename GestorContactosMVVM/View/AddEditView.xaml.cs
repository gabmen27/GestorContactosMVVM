using GestorContactosMVVM.ViewModels;
using GestorContactosMVVM.Models;

using Contact = GestorContactosMVVM.Models.Contact;
namespace GestorContactosMVVM.View;

public partial class AddEditView : ContentPage
{
    private AddEditViewModel viewModel;
    public AddEditView()
    {
        InitializeComponent();
        viewModel = new AddEditViewModel();
        this.BindingContext = viewModel;
    }

    public AddEditView(Contact Contact)
    {
        InitializeComponent();
        viewModel = new AddEditViewModel(Contact);
        this.BindingContext = viewModel;
    }

  
}