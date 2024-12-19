public class Users
{
    public int ID { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Fathername { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public string Password { get; set; }
    public List<int> Cart { get; set; } = new List<int>(); // Инициализация
}
