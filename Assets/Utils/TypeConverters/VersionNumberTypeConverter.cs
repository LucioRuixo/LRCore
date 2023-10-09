using System;
using System.ComponentModel;
using System.Globalization;

namespace LRCore.Utils.TypeConverters
{
    using Packaging;

    public class VersionNumberTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof(VersionNumber) || base.CanConvertTo(context, destinationType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!CanConvertFrom(context, value.GetType()))
            {
                Logger.LogError(typeof(VersionNumberTypeConverter), $"Could not convert object: object can not be converted from type {value.GetType()}.");
                return null;
            }

            string stringValue = (string)value;
            string[] sections = stringValue.Split(VersionNumber.Separator, StringSplitOptions.RemoveEmptyEntries);

            if (sections.Length != VersionNumber.InternalNumbers)
            {
                Logger.LogError(typeof(VersionNumberTypeConverter), $"Could not convert object to VersionNumber: the amount of sections separated by \"{VersionNumber.Separator}\" must be exactly {VersionNumber.InternalNumbers}.");
                return null;
            }

            VersionNumber versionNumber;
            try
            {
                uint major = Convert.ToUInt16(sections[0]);
                uint minor = Convert.ToUInt16(sections[1]);
                uint patch = Convert.ToUInt16(sections[2]);
                versionNumber = new(major, minor, patch);
            }
            catch (Exception exception)
            {
                Logger.LogError(typeof(VersionNumberTypeConverter), $"Could not convert from string to VersionNumber: {exception.Message}.");
                throw;
            }

            return versionNumber;
        }
    }
}