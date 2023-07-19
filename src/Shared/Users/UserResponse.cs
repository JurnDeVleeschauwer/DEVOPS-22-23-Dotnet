using System.Collections.Generic;

namespace Shared.Users
{
    public static class UserResponse
    {
        public class GetIndex
        {
            public List<UserDto.Index> Users { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class Create
        {
            public string Auth0UserId { get; set; }
        }

        public class Detail
        {
            public UserDto.Detail User { get; set; }
        }

        public class Edit
        {
            public String Id { get; set; }
        }

        public class AllAdminsIndex
        {
            public List<AdminUserDto.Index> Admins { get; set; } = new();
            public int Total { get; set; }
        }
    }
}

