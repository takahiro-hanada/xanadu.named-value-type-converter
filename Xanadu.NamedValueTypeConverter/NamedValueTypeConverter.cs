using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Xanadu
{
    public abstract class NamedValueTypeConverter<T> : TypeConverter
    {
        protected abstract IReadOnlyDictionary<string, T> Dictionary { get; }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is T tvalue)
            {
                var kv = Dictionary
                    ?.Select(o => new KeyValuePair<string, T>?(o))
                    ?.Where(o => EqualityComparer<T>.Default.Equals(o.Value.Value, tvalue))
                    ?.SingleOrDefault();
                if (kv != null)
                {
                    return kv.Value.Key;
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string name)
            {
                var dictionary = Dictionary;
                
                if (dictionary != null && dictionary.TryGetValue(name, out T tvalue))
                {
                    return tvalue;
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            => new StandardValuesCollection(Dictionary?.Select(o => o.Value)?.ToArray());

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            => true;

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            => true;
    }
}
