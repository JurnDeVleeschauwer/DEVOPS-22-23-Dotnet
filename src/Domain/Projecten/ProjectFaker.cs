using System.Collections.Generic;
using System.Linq;
using Bogus;
using Domain.Users;
using Domain.VirtualMachines.VirtualMachine;

namespace Domain.Projecten
{
    public class ProjectFaker : Faker<Project>
    {

        private List<Project> _projects = new();


        private static ProjectFaker? _instance;

        public static ProjectFaker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProjectFaker();
                }
                return _instance;
            }
        }


        public ProjectFaker()
        {

            int id = 1;
            CustomInstantiator(e => new Project($"Project: {e.Company.CompanyName()}"));
            RuleFor(x => x.Id, _ => id++);
            RuleFor(x => x.VirtualMachines, _ => VirtualMachineFaker.Instance.Generate(5));
            //RuleFor(x => x.User, _ => UserFaker.Instance.Generate(1)[0]);

        }



        public override List<Project> Generate(int count, string ruleSets = null)
        {
            List<Project> output = new();




            if (_projects.Count() < count)
            {
                output = base.Generate(count, ruleSets);
                output.ForEach(e => _projects.Add(e));
            }
            else
            {
                output = _projects.GetRange(0, count);
            }

            return output;
        }

    }
}

