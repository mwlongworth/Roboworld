// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuaConvert.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Lua
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public static class LuaConvert
    {
        public static string SerializeObject(object value)
        {
            var sb = new StringBuilder();

            Switch(value, sb);
        
            return sb.ToString();
        }

        private static void Switch(object value, StringBuilder sb)
        {
            if (value is string)
            {
                sb.Append("\"");
                sb.Append(value);
                sb.Append("\"");
            }
            else if (value is int)
            {
                sb.Append(value);
            }
            else if (value is IEnumerable<object>)
            {
                SerializeArray((IEnumerable<object>)value, sb);
            }
            else SerializeType(value, sb);
        }

        private static void SerializeArray(IEnumerable<object> collection, StringBuilder sb)
        {
            sb.Append("{");
            var addComma = false;
            foreach (var value in collection)
            {
                if (addComma)
                {
                    sb.Append(",");
                }

                Switch(value, sb);

                addComma = true;
            }

            sb.Append("}");
        }

        private static void SerializeType(object value, StringBuilder sb)
        {
            sb.Append("{");
            var addComma = false;
            foreach (var propertyInfo in value.GetType().GetProperties())
            {
                var propertyValue = propertyInfo.GetValue(value);
                if (propertyValue != null)
                {
                    AddStandard(sb, addComma, propertyInfo);
                    Switch(propertyValue, sb);
                    addComma = true;
                }
            }

            sb.Append("}");
        }

        private static void AddStandard(StringBuilder sb, bool addComma, PropertyInfo propertyInfo)
        {
            if (addComma)
            {
                sb.Append(",");
            }

            sb.Append(propertyInfo.Name);
            sb.Append("=");
        }
    }
}