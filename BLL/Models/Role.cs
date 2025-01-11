namespace LibraryManagementSystem.BLL.Models
{

public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<User> Users { get; set; }  // Many-to-Many relationship
    }
}