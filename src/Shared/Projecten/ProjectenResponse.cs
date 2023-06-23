using System;
using System.Collections.Generic;

namespace Shared.Projecten
{
    public static class ProjectenResponse
    {
        public class GetIndex
        {
            public List<ProjectenDto.Index> Projecten { get; set; } = new();
            public int Total { get; set; }
        }

        public class GetDetail
        {
            public ProjectenDto.Detail Projecten { get; set; }
        }

        public class Delete
        {
        }

        public class Create
        {
            public int ProjectenId { get; set; }
        }

        public class Edit
        {
            public int ProjectenId { get; set; }
        }
    }
}
