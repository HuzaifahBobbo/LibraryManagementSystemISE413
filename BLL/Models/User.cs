namespace LibraryManagementSystem.BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<Role> Roles { get; set; }  // Many-to-Many relationship
    }
}