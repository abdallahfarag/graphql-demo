using GraphQL.Types;
using GraphQlDemo.Enums;
using System.Xml.Linq;

namespace GraphQlDemo.GraphQL.Types
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}
