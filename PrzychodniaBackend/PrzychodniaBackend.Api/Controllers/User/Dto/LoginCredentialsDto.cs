using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.User.Dto
{
    public class LoginCredentialsDto : ValueObject
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Username;
            yield return Password;

        }
    }
}