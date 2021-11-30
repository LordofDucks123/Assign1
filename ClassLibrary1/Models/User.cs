using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Models
{
public class User {
        [Key, MaxLength(25)]
        public string UserName { get; set; }
    public string Domain { get; set; }
    public string City { get; set; }
    public int BirthYear { get; set; }
    public string Role { get; set; }
    public int SecurityLevel { get; set; }
    public string Password { get; set; }
}
}