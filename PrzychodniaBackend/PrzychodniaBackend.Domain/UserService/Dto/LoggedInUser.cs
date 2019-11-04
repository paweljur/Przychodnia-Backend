using System;

namespace PrzychodniaBackend.Application.UserService.Dto
{
    public class LoggedInUser
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public LoggedInUser(string name, string surname)
        {
            Id = Guid.Empty;
            Name = name;
            Surname = surname;
        }
    }
}