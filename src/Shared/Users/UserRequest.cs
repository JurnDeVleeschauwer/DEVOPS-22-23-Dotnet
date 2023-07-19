namespace Shared.Users
{
    public static class UserRequest
    {
        public class GetIndex
        {

        }

        public class Create
        {
            //public KlantDto.Create Klant;

            public UserDto.Create User { get; set; }
        }

        public class AllAdminUsers
        {
            public List<AdminUserDto.Index> AdminUsers { get; set; }
            public int Total { get; set; }
        }
        public class Detail
        {
            public String UserId { get; set; }
        }


        public class Edit
        {
            public String UserId { get; set; }
            public UserDto.Mutate User { get; set; }
        }
    }
}

