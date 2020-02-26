using System.Collections.Generic;
using Xanadu;

namespace Demo
{
    sealed class MyEnumNamedValueTypeConverter : NamedValueTypeConverter<MyEnum?>
    {
        protected override IReadOnlyDictionary<string, MyEnum?> Dictionary => new Dictionary<string, MyEnum?>()
        {
            { "", null },
            { "V0", MyEnum.Value0 },
            { "V1", MyEnum.Value1 },
            { "V2", MyEnum.Value2 },
        };
    }
}
