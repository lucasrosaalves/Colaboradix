namespace Colaboradix.Domain.Enumerations
{
    public class UserType
    {
        public static UserType Admin = new UserType(1, "Admin");
        public static UserType Regular = new UserType(2, "Regular");

        public UserType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
