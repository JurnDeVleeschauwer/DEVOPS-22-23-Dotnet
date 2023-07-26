using Ardalis.GuardClauses;
using Domain.Projecten;
using System;
using System.Collections.Generic;

namespace Domain.Users
{
    public class User : Gebruiker
    {

        /*private string _bedrijfsNaam;
        private User _contactpersoon;
        private List<Project> _projecten;
        private Role _role;
        private Type _type;
        private Course _course;
        private string _typeExtern;

        public String BedrijfsNaam { get { return _bedrijfsNaam; } set { _bedrijfsNaam = Guard.Against.NullOrEmpty(value, nameof(_bedrijfsNaam)); } }
        public User Contactpersoon { get; set; }
        
        public Role Role { get { return _role; } set { _role = Guard.Against.Null(value, nameof(_role)); } }
        public Type Type { get { return _type; } set { _type = Guard.Against.Null(value, nameof(_type)); } }
        public Course Course { get { return _course; } set { _course = Guard.Against.Null(value, nameof(_course)); } }
        public String TypeExtern { get; set; }*/


        public List<Project> Projecten { get; set; }


        /*public User(string name, string firstname, string phoneNumber, string email, string password, Role role, string bedrijfsnaam, Type type, Course course) : base(name, firstname, phoneNumber, email, password)
        {
            this.Name = name;
            this.FirstName = firstname;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Password = password;
            this._role = role;
            this._bedrijfsNaam = bedrijfsnaam;
            this._type = type;
            this._course = course;
        }*/
        public User()
        {
        }
        /*public void addProject(Project p)
        {
            if (_projecten == null)
            {
                _projecten = new List<Project>();
            }
            _projecten.Add(p);
        }*/


    }
}