using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Domain.Common
{
    public class UserProject : Entity
    {
        private int _userId;
        private int _projectId;


        public int UserId
        {
            get { return _userId; }
            set { _userId = Guard.Against.Negative(value, nameof(_userId)); }
        }
        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = Guard.Against.Negative(value, nameof(_projectId)); }
        }




        public UserProject(int u, int p)
        {
            this.UserId = u;
            this.ProjectId = p;

        }


        public UserProject()
        {

        }


        public override string ToString() => $"{UserId} {ProjectId}";
    }
}
