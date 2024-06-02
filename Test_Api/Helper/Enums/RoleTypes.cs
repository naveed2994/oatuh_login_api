namespace Test_Api.Helper.Enums
{

    public enum RoleType
    {
        Admin = 0,
        Player = 1
    }
    public class AppUser
    {
        public AppUser(string name, int role)
        {
            Name = name;
            Role = (RoleType)role;
        }
        public string Name { get; set; }
        public RoleType Role { get; set; }

    }
}
