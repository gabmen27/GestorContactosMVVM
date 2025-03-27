using SQLite;



namespace GestorContactosMVVM.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        public string NumeroTelefono { get; set; }
        public string Correo { get; set; }



    }
}
