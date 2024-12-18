using System.Collections.Generic;

namespace Interior_Center.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string>? Cart { get; set; } // Изменение на список строк
    }
}
