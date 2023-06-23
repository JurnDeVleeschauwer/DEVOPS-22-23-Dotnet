namespace Shared.Projecten
{
    public static class ProjectenRequest
    {
        public class GetIndex
        {
            public string? SearchTerm { get; set; }

        }

        public class GetDetail
        {
            public int ProjectenId { get; set; }
        }

        public class Delete
        {
            public int ProjectenId { get; set; }
        }

        public class Create
        {
            public ProjectenDto.Mutate Projecten { get; set; }
        }

        public class Edit
        {
            public int ProjectenId { get; set; }
            public ProjectenDto.Mutate Projecten { get; set; }
        }
    }
}
