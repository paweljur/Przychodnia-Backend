namespace PrzychodniaBackend.Core.Domain.Entities
{
    public class IcdCode
    {
        public long Id { get; private set; }
        public string Code { get; private set; }
        public string Group { get; private set; }
        public string Subgroup { get; private set; }
        public string Value { get; private set; }
        public string? Subvalue { get; private set; }

        public IcdCode(string code, string group, string subgroup, string value, string? subvalue = null)
        {
            Code = code;
            Group = group;
            Subgroup = subgroup;
            Value = value;
            Subvalue = subvalue;
        }
    }
}
