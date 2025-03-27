
using GestorContactosMVVM.Models;
using SQLite;
using Contact = GestorContactosMVVM.Models.Contact;

namespace GestorContactosMVVM.Services
{
    public class ContactsDataBase
    {
        private readonly SQLiteConnection _connection;

        public ContactsDataBase() 
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Contact.db3");

            _connection = new SQLiteConnection(dbPath);

            //Table Created
            _connection.CreateTable<Contact>();

          
                      

        }

        public List<Contact> GetAll() 
        {
            return _connection.Table<Contact>().ToList();
        }

        public int Insert(Contact Contact) 
        {
            return _connection.Insert(Contact);
        }

        public int Update(Contact Contact) 
        {
            return _connection.Update(Contact);
        }

        public int Delete(Contact Contact) 
        {
            return _connection.Delete(Contact);

        }

    }
}
