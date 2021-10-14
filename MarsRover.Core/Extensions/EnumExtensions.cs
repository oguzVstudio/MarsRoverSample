using MarsRover.Core.DataObjects.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MarsRover.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static IEnumerable<TEnum> GetValues<TEnum>(this Enum @enum)
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            return values;
        }

        public static IList<EnumLookup> GetEnumLookup(this Enum @enum)
        {
            var values = Enum.GetValues(@enum.GetType()).Cast<Enum>();

            var list = values.Select(u => new EnumLookup
            {
                Value = Enum.GetName(@enum.GetType(), u),
                Text = u.GetDescription(),
                Key = Convert.ToInt32(u)
            }).ToList();

            return list;
        }
    }
}
