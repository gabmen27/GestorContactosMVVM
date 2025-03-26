using SQLite;
using System.ComponentModel.DataAnnotations;


namespace GestorContactosMVVM.Models
{
    public class Contacts
    {
        [PrimaryKey]
        public string numeroTelefono { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
                
    }
}
