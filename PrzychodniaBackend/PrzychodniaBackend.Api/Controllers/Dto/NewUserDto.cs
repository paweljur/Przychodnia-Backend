using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.Dto
{
    public class NewUserDto : ValueObject
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Surname;
            yield return Username;
            yield return Password;
            yield return Role;
        }
    }
}
