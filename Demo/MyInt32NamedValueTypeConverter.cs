using System.Collections.Generic;
using Xanadu;

namespace Demo
{
    sealed class MyInt32NamedValueTypeConverter : NamedValueTypeConverter<int?>
    {
        protected override IReadOnlyDictionary<string, int?> Dictionary => new Dictionary<string, int?>()
        {
            { "", null },
            { "One", 1 },
            { "Two", 2 },
            { "San", 3 },
        };
    }
}
