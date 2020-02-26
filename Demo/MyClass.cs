using System.ComponentModel;

namespace Demo
{
    sealed class MyClass
    {
        [DefaultValue(0)]
        [TypeConverter(typeof(MyInt32NamedValueTypeConverter))]
        public int? Int32Value { get; set; }

        [DefaultValue(0)]
        [TypeConverter(typeof(MyEnumNamedValueTypeConverter))]
        public MyEnum? MyEnumValue { get; set; }
    }
}
